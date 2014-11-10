using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PixTools;
using System.Threading;
using HookBox;

namespace PixBot
{
    public partial class Form1 : Form
    {

        bool actionDone = false;
        public delegate void updatetextBoxCallBack();
        public delegate void updatetextBoxPixelCallBack();
        public delegate void updatetextBoxTimerCallBack();
        private KeyMessageFilter m_filter = new KeyMessageFilter();
        private RegisterAction R;
        public MouseControler m_MC { get; set; }
        public Hook m_KeyHook { get; set; }
        public Hook m_KeyHook2 { get; set; }
        private bool lancer;
        string fileToOpen;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Chargement de la page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Application.AddMessageFilter(m_filter);
            m_KeyHook = new Hook(Hook.HookType.KeyBoard, Hook.HookVisibility.Global);
            m_KeyHook.OnKeyDown += OnKeyboardAction;
            m_KeyHook2 = new Hook(Hook.HookType.KeyBoard, Hook.HookVisibility.Global);
            m_KeyHook2.OnKeyDown += OnKeyboardAction2;
            lancer = false;
            Frequence.Maximum = 10000;
            Frequence.Minimum = 100;
            actionDone = false;
            m_MC = new MouseControler();
            m_MC.GlobalHook.OnMouseClick += OnMouseClicked;
            


        }


        #region ButtonClick
        /// <summary>
        /// Bouton pour afficher la couleur du pixel en X;Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(PixelBox.getPixel(int.Parse(pixelCoord.Text.Split(';')[0]), int.Parse(pixelCoord.Text.Split(';')[1])).toString());
            }
            catch
            {
                pixelCoord.Text = "Erreur dans les coordonnées";
            }
        }


        /// <summary>
        /// Lorsque on input une image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               fileToOpen = openFileDialog1.FileName;
                pictureBox1.Image = new Bitmap(fileToOpen).GetThumbnailImage(100, 100, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            }
        }

        /// <summary>
        /// Lorsque on enregistre les mouvements de la sourie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseDL_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                mouseDL.Text = "Cliquez pour remplacer l'action existante (Appuyez sur F11 pour arreter)";
                timer2.Enabled = false;
                m_KeyHook.Stop();
                m_MC.GlobalHook.Stop();
                m_MC.LocalHook.Stop();

            }
            else
            {                
                mouseDL.Text = "En enregistrement";
                R = new RegisterAction();
                m_KeyHook.Start();
                m_MC.GlobalHook.Start();
                m_MC.LocalHook.Start();
                timer2.Enabled = true;
                this.Hide();

            }

        }

        #endregion



        #region deleguePourri
        /// <summary>
        /// Delegué inutile pour le thumbnail
        /// </summary>
        /// <returns></returns>
        public bool ThumbnailCallback()
        {
            return false;
        }
#endregion



        #region boucleTimer
        /// <summary>
        /// boucle pour la detection d'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageDetection(object sender, EventArgs e)
        {            
            if (lancer)
            {
                Thread fred = new Thread(new ThreadStart(threadFunc));
                fred.Start();
            }
           // pictureBox1.Image = new Bitmap("C:\\Users\\Zunk\\Desktop\\Capture.png");//.GetThumbnailImage(new Bitmap("C:\\Users\\Zunk\\Desktop\\Capture.png").Width / 2, new Bitmap("C:\\Users\\Zunk\\Desktop\\Capture.png").Height/2, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        }


        #region tools
        /// <summary>
        /// La boucle d'analyse d'image arrive ici, si une demande est exigé
        /// </summary>
        public void threadFunc()
        {
            if(radioButton2.Checked)
                pixLab.Invoke(new updatetextBoxCallBack(this.updatetextBox));
            else if(radioButton1.Checked)
                pixLab.Invoke(new updatetextBoxPixelCallBack(this.updatetextPixelBox));
            else if(radioButton3.Checked)
                pixLab.Invoke(new updatetextBoxTimerCallBack(this.updatetextTimerBox));

        }
        /// <summary>
        /// l'analyse par en fonction du temps a été demandé, nous effectuons alors l'analyse de l'heure
        /// </summary>
        public void updatetextTimerBox()
        {
            string houre = detectHoure.Text.Split(':')[0];
            string minute = detectHoure.Text.Split(':')[1];
            if(DateTime.Now.Hour==int.Parse(houre) && DateTime.Now.Minute==int.Parse(minute))
            {
                pixLab.Visible = true;
                pixLab.Text = "Il est l'heure, l'action pré enregistré se lance !";
                if (!actionDone) Action();
            }
        }
        /// <summary>
        /// l'analyse par pixel a été demandé, nous effectuons alors l'analyse
        /// </summary>
        public void updatetextPixelBox()
        {
            try
            {
                Pixel p = PixelBox.getPixel(int.Parse(pixelAnalyseCoord.Text.Split(';')[0]), int.Parse(pixelAnalyseCoord.Text.Split(';')[1]));
                int R, G, B, A;
                R = int.Parse(ColorTB.Text.Split('/')[0]);
                G = int.Parse(ColorTB.Text.Split('/')[1]);
                B = int.Parse(ColorTB.Text.Split('/')[2]);
                A = int.Parse(ColorTB.Text.Split('/')[3]);

                if (A == p.A && G == p.G && R == p.R && B == p.B)
                {
                    pixLab.Visible = true;
                    pixLab.Text = "Pixel detecté sur l'écran, l'action pré enregistré se lance !";
                    if (!actionDone) Action();
                }
                else
                {
                    pixLab.Visible = false;
                }
            }
            catch
            {
                pixLab.Visible = true;
                pixLab.Text = "Erreur dans les couleurs pixel fournis, le format à respecter est : valeurRouge/valeurVerte/ValeurBleu/Alpha !\n Vous pouvez trouvez ces valeurs grâce à l'outil d'analyse de pixel fournis plus haut !";
            }

            
        }


        /// <summary>
        /// l'analyse par image a été demandé, nous effectuons alors l'analyse
        /// </summary>
        public void updatetextBox()
        {
            if (fileToOpen != null)
            {
                if (PixelBox.isOnScreen(new Bitmap(fileToOpen)))
                {
                    pixLab.Visible = true;
                    pixLab.Text = "Image detecté sur l'écran, l'action pré enregistré se lance !";
                    if (!actionDone)Action();
                }
                else pixLab.Visible = false;
               // pixLab.Text = PixelBox.isOnScreen(new Bitmap(fileToOpen)).ToString();
            }
        }

        /// <summary>
        /// On effectue l'action
        /// </summary>
        private void Action()
        {            
            foreach (PixTools.Action A in R.L)
            {
                if (A is MouseAction)
                {
                    m_MC.DoMouseMove(((MouseAction)A).e.X, ((MouseAction)A).e.Y);
                    Thread.Sleep(1000);
                    m_MC.DoMouseClick(MouseControler.ButtonType.Left, ((MouseAction)A).e.X, ((MouseAction)A).e.Y);                                        
                    Thread.Sleep(1000);
                }
                if (A is KeyboardAction)
                {
                    SendKeys.Send(((KeyboardAction)A).touche);
                    Thread.Sleep(1000);
                }
            }
            this.Show();
            actionDone = true;
            GO.Text = "Lancer";
            lancer = false;
        }

        #endregion

        /// <summary>
        /// boucle d ecoute des mouvements de la sourie, enabled avec l actioon sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

#endregion


        #region Event


        /// <summary>
        /// Enregistrement action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyboardAction(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F11)
            {
                mouseDL.Text = "Cliquez pour remplacer l'action existante (Appuyez sur F11 pour arreter l'enregistrement)";
                timer2.Enabled = false;
                m_KeyHook.Stop();
                m_MC.GlobalHook.Stop();
                m_MC.LocalHook.Stop();
                this.Show();
            }
            else R.addKeyboardAction(e.KeyData.ToString());
        }


        /// <summary>
        /// Programme lancé, verifie si on veut annuler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyboardAction2(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                actionDone = true;
                GO.Text = "Lancer";
                lancer = false;
                this.Show();
            }
           
        }

        public void OnMouseClicked(object sender, MouseEventArgs e)
        {
           
           if( e.Button!=MouseButtons.None)
                R.addMouseAction(e);
           
             
        }

        #endregion

        /// <summary>
        /// Bouton permettant de lancer l'analyse d'image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (!lancer)
            {
                m_KeyHook2.Start();
                GO.Text = "En cours";
                lancer = true;
                actionDone = false;
                if(this.checkBox1.Checked)this.Hide();
            }
            else
            {
                m_KeyHook2.Stop();
                GO.Text = "Lancer";
                lancer = false;
            }
        }

        /// <summary>
        ///  Boutton d affiche des données frequence et pixel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            chronoLab.Text = "Position en Pixel : " + Control.MousePosition.X + ";" + Control.MousePosition.Y;
            FrequenceLab.Text = "Frequence d'analyse (en milliseconde) : " + Frequence.Value.ToString();
            if (timer1.Interval != Frequence.Value) timer1.Interval = Frequence.Value;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }
















    }
}

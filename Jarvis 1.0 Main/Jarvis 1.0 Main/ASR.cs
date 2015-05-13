using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Speech.Recognition.SrgsGrammar;
using System.Speech.Recognition;
using System.IO.Ports;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;


namespace Jarvis_1._0_Main
{
    class ASR
    {
        public bool standby = false;
        public bool merciPrononcé = false;
        public string control = "0";
        public SpeechRecognitionEngine ASREngine;
        private Label recoText;
        private Label affiche;
        private GrammarBuilder gram_build;
        Choices choice;
        Grammar gram;
        SpeechSynthesizer synthese = new SpeechSynthesizer();


        public ASR(ref Label recoText, ref Label affiche)
        {
            this.recoText = recoText;
            this.affiche = affiche;
            List<string> list_chemin = new List<string>() {"custom.txt", "test.txt"};
            choice = new Choices(analyTxt(list_chemin));
            this.gram_build = new GrammarBuilder(choice);


            for (int i = 0; i < 10; i++ )
            {
                this.gram_build.Append(choice);
            }

            gram = new Grammar(gram_build);
            StartEngine();
        }

        
        public string[] analyTxt (string chemin)
        {
            StreamReader str_read = new StreamReader(chemin, Encoding.Default);
            string mot = "";
            string text = str_read.ReadToEnd();
            List<string> list = new List<string>();
            string[] tab;

            for(int i = 0; i < text.Length; i++)
            {
                if (text[i] != '\r' && text[i] != '\n')
                {
                    mot += text[i];
                }
                else
                {
                    if(mot != "" && mot.Length > 1)
                        list.Add(mot);
                    mot = "";
                }
            }
            
            tab = new string[list.Count];
            for(int i = 0; i < list.Count; i++)
            {
                tab[i] = list[i];
            }

            return tab;
        }




        public string[] analyTxt(List<string> list_chemin)
        {
            List<string> list = new List<string>();
            string[] tab;
            string mot = "";


            for(int j = 0; j < list_chemin.Count; j++)
            {
                StreamReader str_read = new StreamReader(list_chemin[j], Encoding.Default);
                string text = str_read.ReadToEnd();


                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != '\r' && text[i] != '\n')
                    {
                        mot += text[i];
                    }
                    else
                    {
                        if (mot != "" && mot.Length > 1)
                            list.Add(mot);
                        mot = "";
                    }
                }
            }

            tab = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                tab[i] = list[i];
            }

            return tab;
        }

















        private void StartEngine()
        {
            

            //////////////////////////SrgsDocument xmlGrammar = new SrgsDocument("Grammaire.grxml");
            //////////////////////////Grammar grammar = new Grammar(xmlGrammar);
            //////////////////////////SrgsDocument xmlGrammar2 = new SrgsDocument("Grammaire2.grxml");
            //////////////////////////Grammar grammar2 = new Grammar(xmlGrammar);
            ASREngine = new SpeechRecognitionEngine();
            ASREngine.SetInputToDefaultAudioDevice();
            ////////////////////////ASREngine.LoadGrammar(grammar);
            ////////////////////////ASREngine.LoadGrammar(grammar2);

            ASREngine.LoadGrammar(gram);

            //////////////////////ASREngine.SpeechRecognized += ASREngine_SpeechRecognized;
            ASREngine.SpeechRecognitionRejected += ASREngine_SpeechRecognitionRejected;
            ASREngine.SpeechHypothesized += ASREngine_SpeechHypothesized;
            ASREngine.MaxAlternates = 1;
            synthese.SetOutputToDefaultAudioDevice();
            //synthese.Speak("Bonjour Monsieur, ravi de vous revoir");
        }

        private void ASREngine_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            SpeechSynthesizer synthese = new SpeechSynthesizer();
            synthese.SetOutputToDefaultAudioDevice();
            recoText.Text = "Hypothèse : " + e.Result.Text;
            affiche.Text = "";
            string hypothese = e.Result.Text;
            string Ordre = ProcessReco(hypothese);
            affiche.Text = Ordre;
            if (Ordre.Contains("bonjour")) {hypothese = ""; synthese.Speak("Bonjour Monsieur"); }
            if (Ordre.Contains("musique") && Ordre.Contains("demarrer")) { hypothese = ""; Process.Start("c:\\Eiffel65.mp3"); }
            if (Ordre.Contains("musique") && Ordre.Contains("arreter")) { hypothese = ""; KillProcess("vlc"); }
        }

        private void ASREngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            recoText.Text = "Ordre non reconnu";
            affiche.Text = "";
        }

        ////////////////////////private void ASREngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        ////////////////////////{
        ////////////////////////    recoText.Text = e.Result.Text;
        ////////////////////////    affiche.Text = "";
        ////////////////////////    string baseCommand = e.Result.Semantics["mouskie"].Value.ToString();
        ////////////////////////    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        ////////////////////////    Random random = new Random();
        ////////////////////////    if (standby == false)

        ////////////////////////        switch (baseCommand)
        ////////////////////////        {

        ////////////////////////            case "QUIT":
        ////////////////////////                player.SoundLocation = "c:\\Jarvis\\Voix\\Au revoir Monsieur.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(2500);
        ////////////////////////                player.Stop();
        ////////////////////////                Environment.Exit(0);
        ////////////////////////                break;
        ////////////////////////            case "Bonjour":
        ////////////////////////                affiche.Text = "Bonjour Monsieur";
        ////////////////////////                player.SoundLocation = "c:\\Jarvis\\Voix\\Bonjour Monsieur.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(1800);
        ////////////////////////                player.Stop();
        ////////////////////////                baseCommand = "0";
        ////////////////////////                break;
        ////////////////////////            case "YES":
        ////////////////////////                affiche.Text = "Que puis-je pour vous Monsieur?";
        ////////////////////////                player.SoundLocation = "c:\\Jarvis\\Voix\\Que puis-je faire pour vous monsieur1.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.PlayLooping();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(2300);
        ////////////////////////                player.Stop();
        ////////////////////////                break;
        ////////////////////////            case "DATE":
        ////////////////////////                affiche.Text = DateTime.Now.ToString("");
        ////////////////////////                string jour = DateTime.Now.ToString("dd");
        ////////////////////////                string mois = DateTime.Now.ToString("MM");
        ////////////////////////                player.SoundLocation = "C:\\Jarvis\\Date\\Nous sommes le.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(1300);
        ////////////////////////                player.Stop();
        ////////////////////////                player.SoundLocation = "C:\\Jarvis\\Date\\Jours\\" + jour + ".wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(800);
        ////////////////////////                player.Stop();
        ////////////////////////                player.SoundLocation = "C:\\Jarvis\\Date\\Mois\\" + mois + ".wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(700);
        ////////////////////////                player.Stop();
        ////////////////////////                player.SoundLocation = "C:\\Jarvis\\Date\\Mois\\2014.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(1050);
        ////////////////////////                player.Stop();
        ////////////////////////                merciPrononcé = false;
        ////////////////////////                break;
        ////////////////////////            case "HEURE":
        ////////////////////////                affiche.Text = DateTime.Now.ToString("");
        ////////////////////////                string heure = DateTime.Now.ToString("HH");
        ////////////////////////                string min = DateTime.Now.ToString("mm");
        ////////////////////////                player.SoundLocation = "C:\\Jarvis\\Date\\Il est.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(700);
        ////////////////////////                player.Stop();
        ////////////////////////                player.SoundLocation = "C:\\Jarvis\\Date\\Temps\\" + heure + ".wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(700);
        ////////////////////////                player.Stop();
        ////////////////////////                player.SoundLocation = "C:\\Jarvis\\Date\\heures et.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(700);
        ////////////////////////                player.Stop();
        ////////////////////////                player.SoundLocation = "C:\\Jarvis\\Date\\Temps\\" + min + ".wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(1000);
        ////////////////////////                player.Stop();
        ////////////////////////                player.SoundLocation = "C:\\Jarvis\\Date\\minutes Monsieur.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.Play();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(1000);
        ////////////////////////                player.Stop();
        ////////////////////////                merciPrononcé = false;
        ////////////////////////                break;
        ////////////////////////            case "YOU SIR":
        ////////////////////////                int random1 = random.Next(1, 3);
        ////////////////////////                affiche.Text = "C'est vous Monsieur";
        ////////////////////////                switch (random1)
        ////////////////////////                {
        ////////////////////////                    case 1:
        ////////////////////////                        player.SoundLocation = "c:\\Jarvis\\Voix\\C'est vous Monsieur.wav";
        ////////////////////////                        break;
        ////////////////////////                    case 2:
        ////////////////////////                        player.SoundLocation = "c:\\Jarvis\\Voix\\Mais c'est vous Monsieur.wav";
        ////////////////////////                        break;
        ////////////////////////                }
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.PlayLooping();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(1300);
        ////////////////////////                player.Stop();
        ////////////////////////                merciPrononcé = true;
        ////////////////////////                break;
        ////////////////////////            case "MERCI":
        ////////////////////////                if (merciPrononcé == true)
        ////////////////////////                {
        ////////////////////////                    affiche.Text = "Merci Jarvis";
        ////////////////////////                    player.SoundLocation = "c:\\Jarvis\\Voix\\Mais de rien Monsieur.wav";
        ////////////////////////                    player.LoadAsync();
        ////////////////////////                    player.PlayLooping();   //asynchronous (loop)playing in new thread
        ////////////////////////                    System.Threading.Thread.Sleep(1300);
        ////////////////////////                    player.Stop();
        ////////////////////////                    merciPrononcé = false;
        ////////////////////////                }
        ////////////////////////                break;
        ////////////////////////            case "PAPAS":
        ////////////////////////                affiche.Text = "Ce sont vous et Xdarwin Monsieur";
        ////////////////////////                player.SoundLocation = "c:\\Jarvis\\Voix\\Ce sont vous et Xdarwin Monsieur.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.PlayLooping();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(2300);
        ////////////////////////                player.Stop();
        ////////////////////////                merciPrononcé = false;
        ////////////////////////                break;
        ////////////////////////            case "MUSIC":
        ////////////////////////                Process.Start("c:\\VLC 2.xspf");
        ////////////////////////                merciPrononcé = false;
        ////////////////////////                break;
        ////////////////////////            case "MUSIC STOP":
        ////////////////////////                Process[] localByName = Process.GetProcessesByName("vlc");
        ////////////////////////                foreach (Process p in localByName)
        ////////////////////////                {
        ////////////////////////                    p.Kill();
        ////////////////////////                }
        ////////////////////////                merciPrononcé = false;
        ////////////////////////                break;
        ////////////////////////            case "MK3":
        ////////////////////////                Process.Start("c:\\Jarvis MK3\\Jarvis MK3\\bin\\Release\\Jarvis MK3.exe");
        ////////////////////////                standby = true;
        ////////////////////////                merciPrononcé = false;
        ////////////////////////                break;

        ////////////////////////            case "QUIT RECO":
        ////////////////////////                standby = true;
        ////////////////////////                player.SoundLocation = "c:\\Jarvis\\Voix\\Je passe en veille Monsieur.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.PlayLooping();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(2300);
        ////////////////////////                player.Stop();
        ////////////////////////                merciPrononcé = false;
        ////////////////////////                break;


        ////////////////////////        }
        ////////////////////////    else
        ////////////////////////        switch (baseCommand)
        ////////////////////////        {
        ////////////////////////            case "START RECO":
        ////////////////////////                player.SoundLocation = "c:\\Jarvis\\Voix\\Reconnaissance vocale opérationnelle Monsieur.wav";
        ////////////////////////                player.LoadAsync();
        ////////////////////////                player.PlayLooping();   //asynchronous (loop)playing in new thread
        ////////////////////////                System.Threading.Thread.Sleep(2300);
        ////////////////////////                player.Stop();
        ////////////////////////                standby = false;
        ////////////////////////                break;
        ////////////////////////        }
        ////////////////////////    ;
        ////////////////////////}



        public string ProcessReco(string Reco)
        {
            string Ordre = "";
            List<string> demarrer = new List<string>() { "démarr", "lance", "initi" };
            List<string> arreter = new List<string>() { "arrêt", "coupe", "eteind" };
            List<string> musique = new List<string>() { "musique", "chanson", "playlist" };
            List<string> bonjour = new List<string>() { "bonjour Jarvis" };
            Ordre = VerifCoresspondace(Reco, demarrer, "demarrer", Ordre);
            Ordre = VerifCoresspondace(Reco, arreter, "arreter", Ordre);
            Ordre = VerifCoresspondace(Reco, musique, "musique", Ordre);
            Ordre = VerifCoresspondace(Reco, bonjour, "bonjour", Ordre);
            return Ordre;
        }

        public string VerifCoresspondace(string Reco, List<string> choix, string retour, string Ordre)
        {
            bool verif = false;
            for (int i = 0; i < choix.Count; i++)
            {
                if (Reco.Contains(choix[i]))
                {
                    verif = true;
                }
            }
            if (verif == true)
            {
                Ordre = Ordre + " " + retour;
            }

            return Ordre;
        }

        public void COMWrite(string msg, int SerialPort)
        {
            string Serial = "COM" + SerialPort.ToString();
            try
            {
                SerialPort COM = new SerialPort(Serial);
                COM.Open();
                COM.Write(msg);
                COM.Close();
            }
            catch
            {
                synthese.Speak("Le périphérique recherché est hors de portée Monsieur");
            }
        }

        public void KillProcess(string process)
        {
            Process[] localByName = Process.GetProcessesByName(process);
            foreach (Process p in localByName)
             {
             p.Kill();
            }
        }
    }
}
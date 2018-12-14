using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace ClientChat
{
    public partial class Chat : Form
    {

        private void invia(string stringa_inviata)
        {
            Byte[] bytes_da_inviare = Encoding.ASCII.GetBytes(stringa_inviata);
            stream.Write(bytes_da_inviare, 0, bytes_da_inviare.Length);
        }
        private string leggi()
        {
            string stringa_ricevuta = "";
            int numero_bytes;
            do
            {

                numero_bytes = stream.Read(bytes, 0, cliente.ReceiveBufferSize);
                stringa_ricevuta += Encoding.ASCII.GetString(bytes, 0, numero_bytes);

            } while (numero_bytes >= cliente.ReceiveBufferSize);
            return stringa_ricevuta;
        }
        TcpClient cliente;
        string nome;
        string id;
        Byte[] bytes;
        NetworkStream stream;
        bool updated = false;
        Thread ctThread;
        Random randomColori;
        Dictionary<string, int> dizionarioColori;

        public Chat(TcpClient cliente, string nome, string id)
        {
            
            InitializeComponent();
            this.cliente = cliente;
            this.nome = nome;
            this.id = id;

            randomColori = new Random();
            dizionarioColori = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
            bytes = new Byte[cliente.ReceiveBufferSize];
            stream = cliente.GetStream();

            this.Text = "Chat di ["+nome+"]";

            aggiornaLista.Tick += new System.EventHandler(chiediLista);
            aggiornaLista.Start();

            ctThread = new Thread(ricevi);
            ctThread.Start();
            

        }

        private void ricevi()
        {
            while (true)
            {
                string ricevuto = leggi();
                if (ricevuto != "OK")
                {
                    char loSwitch = ricevuto[0];
                    ricevuto = ricevuto.Substring(1);

                    switch (loSwitch)
                    {
                        case 'U':
                            string[] arrayUtenti =ricevuto.Split('|');
                            List<string> appoggio = utenti.Items.OfType<string>().ToList<string>();
                            foreach (string utente in appoggio)
                            {
                                if (!arrayUtenti.Contains<string>(utente))
                                {
                                    cancella(utenti, utente);
                                    //dizionarioColori.Remove(utente);
                                    add(utentiOffline, utente);
                                }
                            }
                            for(int i=0;i<arrayUtenti.Length;i++)
                            {
                                if (arrayUtenti[i] != nome)
                                {
                                    if(utentiOffline.Items.Contains(arrayUtenti[i]))
                                    {
                                        add(utenti, arrayUtenti[i]);
                                        cancella(utentiOffline, arrayUtenti[i]);
                                    }
                                    else if(!utenti.Items.Contains(arrayUtenti[i]))
                                    {
                                        add(utenti, arrayUtenti[i]);
                                        dizionarioColori.Add(arrayUtenti[i], randomColori.Next(0, 255));
                                    }
                                    
                                }
                            }

                            updated = false;
                            break;
                        case 'M':
                            string mittente = ricevuto.Split('|')[0];
                            string messaggio = ricevuto.Split('|')[1];

                            ricevi(riceviMex,"|"+mittente+"|: "+messaggio );

                            break;
                        case 'R':
                            ricevuto.Replace(",", ", ");
                            error("Impossibile inviare il messaggio a "+ricevuto);
                            break;

                    }
                }
                else
                    info("Tutto OK");


            }

        }
        
        delegate void addUtenti(ListBox lista,string utente);

        private void add(ListBox lista,string utente)
        {
        
            if (lista.InvokeRequired)
            {
                addUtenti d = new addUtenti(add);
                this.Invoke(d, new object[] { lista, utente });
            }
            else
            {
                lista.Items.Add(utente);
            }
        }

        delegate void riceviMessaggi(RichTextBox ricevi, string messaggio);

        private void ricevi(RichTextBox riceviTB, string messaggio)
        {
            if (riceviTB.InvokeRequired)
            {
                riceviMessaggi d = new riceviMessaggi(ricevi);
                this.Invoke(d, new object[] { riceviTB, messaggio });
            }
            else
            {
                string utente = messaggio.Split('|')[1];
                string testo = messaggio.Split('|')[2];
                riceviTB.SelectionAlignment = HorizontalAlignment.Left;
                riceviTB.AppendText("|");
                riceviTB.SelectionColor = getColoreUtente(utente);
                riceviTB.AppendText(utente);
                riceviTB.SelectionColor = riceviTB.ForeColor;

                //riceviTB.SelectionStart = riceviTB.TextLength;
                //riceviTB.SelectionColor = riceviTB.ForeColor;
                riceviTB.AppendText("|" +testo + Environment.NewLine);
                riceviTB.Select(riceviTB.GetFirstCharIndexFromLine(riceviTB.Lines.Length-2), riceviTB.Lines[riceviTB.Lines.Length - 2].Length);
                //string appo = @"{\pict\pngblip\picw100\pich100\picwgoal5924\pichgoal1860 " + BitConverter.ToString(Properties.Resources.felice).Replace("-", "") + " }".Replace("-","");

                //appo.Replace(":)", @"\pict\pngblip\picw10449\pich3280\picwgoal5924\pichgoal1860 "+ BitConverter.ToString(Properties.Resources.felice) +"");
                
                //riceviTB.SelectedRtf = riceviTB.SelectedRtf.Replace(":)", @"\pict\pngblip\picw100\pich100\picwgoal5924\pichgoal1860 " + BitConverter.ToString(Properties.Resources.felice).Replace("-", "") + " ");

            }
        }
        delegate void scriviMessaggi(RichTextBox invia, string messaggio);
        private void scrivi(RichTextBox inviaTB, string messaggio)
        {

            if (inviaTB.InvokeRequired)
            {
                riceviMessaggi d = new riceviMessaggi(ricevi);
                this.Invoke(d, new object[] { inviaTB, messaggio });
            }
            else
            {
                
                string utente = messaggio.Split('|')[0];
                string testo = messaggio.Split('|')[1];
                string[] listaUtenti;
                inviaTB.SelectionAlignment = HorizontalAlignment.Right;
                inviaTB.AppendText("|");
                if (utente == "*")
                {
                    inviaTB.AppendText("*|:" + testo + Environment.NewLine);
                }
                else
                {
                    listaUtenti = utente.Split(',');
                    foreach (string corrente in listaUtenti)
                    {
                        inviaTB.SelectionColor = getColoreUtente(corrente);
                        inviaTB.AppendText(corrente);
                        inviaTB.SelectionColor = inviaTB.ForeColor;
                        if(corrente != listaUtenti.Last())
                            inviaTB.AppendText(",");
                    }
                    

                    //riceviTB.SelectionStart = riceviTB.TextLength;
                    //riceviTB.SelectionColor = riceviTB.ForeColor;
                    inviaTB.AppendText("|: " + testo + Environment.NewLine);
                }
               // inviaTB.SelectionAlignment = HorizontalAlignment.Left;
            }
        }
        delegate void cancellaUtenti(ListBox lista, string utente);

        private void cancella(ListBox lista, string utente)
        {
            if (lista.InvokeRequired)
            {
                cancellaUtenti d = new cancellaUtenti(cancella);
                this.Invoke(d, new object[] { lista, utente });
            }
            else
            {
                lista.Items.Remove(utente);
            }
        }
        private void chiediLista(object sender, EventArgs e)
        {
            if (!updated)
            {
                invia("L");
                updated = true;
            }
        }

        private void Chat_Load(object sender, EventArgs e)
        {

        }
        private void info(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void error(string message)
        {
            MessageBox.Show(message, "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            cliente = null;
            Environment.Exit(0);
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }
        private void inviaMessaggio_Click(object sender, EventArgs e)
        {
            string messaggio = "M";
            if (utenti.SelectedIndex == -1)
            {
                error("Seleziona almeno un utente!");
            }
            else if (inviaMex.Text == "")
            {
                error("Inserisci del testo");
            }
            else if(inviaMex.Text.Contains("|"))
            {
                error("Non è possibile inviare messaggi contenenti il carattere '|'");
            }
            else
            {
                foreach(string utente in utenti.SelectedItems)
                {
                    messaggio += utente + ",";
                }
                messaggio = messaggio.Substring(0, messaggio.Length - 1);
                //MessageBox.Show(messaggio);
                messaggio += "|" + inviaMex.Text;
                invia(messaggio);
                scrivi(riceviMex, messaggio.Substring(1));
            }
        }
        private void inviaTutti_Click(object sender, EventArgs e)
        {
            if (inviaMex.Text == "")
            {
                error("Inserisci del testo");
            }
            else if (utenti.Items.Count == 0)
            {
                error("Non ci sono altri utenti");
            }
            else if (inviaMex.Text.Contains("|"))
            {
                error("Non è possibile inviare messaggi contenenti il carattere '|'");
            }
            else
            {
                invia("M*|" + inviaMex.Text);
                scrivi(riceviMex,"*|" + inviaMex.Text);
            }
        }
        private Color getColoreUtente(string nomeUtente)
        {
            int numeroColore = dizionarioColori[nomeUtente];
            Random tempRandom = new Random(numeroColore);
            return Color.FromArgb(numeroColore, tempRandom.Next(255), tempRandom.Next(255));
        }
        private void utenti_DrawItem(object sender, DrawItemEventArgs e)
        {
            StringFormat format = new StringFormat(StringFormat.GenericDefault);
            format.LineAlignment = StringAlignment.Center;
            //info(sender.ToString());
            if (e.Index != -1)
            {
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2));
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, Brushes.Black, new Rectangle(e.Bounds.X + 32 + 5 + 3, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height - 2), format);
                e.Graphics.FillRectangle(Brushes.White, new Rectangle(e.Bounds.X + 3 + 5 + 3, e.Bounds.Y + 3, 27, 27));
                e.Graphics.FillRectangle(new SolidBrush(getColoreUtente(((ListBox)sender).Items[e.Index].ToString())), new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 3, 5, 27));
                if (((ListBox)sender).GetSelected(e.Index))
                {
                    e.Graphics.DrawImage(ClientChat.Properties.Resources.icon, new Rectangle(e.Bounds.X + 3 + 5 + 3, e.Bounds.Y + 3, 27, 27));
                }
            }

        }

        private void utenti_Click(object sender, EventArgs e)
        {
           
        }

        private void utenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            utenti.Invalidate();
        }

        private void resocontoMex_Click(object sender, EventArgs e)
        {
            ListBox appo=utenti;
            if(tabControl1.SelectedTab.Text == "Offline")
            {
                appo = utentiOffline;
            }
            
            if (appo.SelectedIndex == -1)
            {
                error("Seleziona un utente!");
            }
            else if(appo.SelectedItems.Count>1)
            {
                error("Seleziona solo un utente!");
            }
            else
            {
                List<Tuple<string,HorizontalAlignment>> linee = new List<Tuple<string, HorizontalAlignment>>();
               // string linee="";
                string utenteSelezionato = appo.SelectedItem.ToString();
                string[] utenti;
                string linea;
                for(int i=0;i< riceviMex.Lines.Length;i++)
                {
                    
                    linea = riceviMex.Lines[i];
                    if (linea != "")
                    {
                        utenti = linea.Split('|')[1].Split(',');
                        foreach (string utente in utenti)
                        {
                            if (utente == utenteSelezionato || utente == "*")
                            {
                                riceviMex.Select(riceviMex.GetFirstCharIndexFromLine(i), linea.Length);
                                //info(riceviMex.SelectionAlignment.ToString());
                                linee.Add(new Tuple<string, HorizontalAlignment>(riceviMex.SelectedRtf, riceviMex.SelectionAlignment));
                                break;
                            }
                        }
                    }
                }
                if(linee.Count ==0)
                {
                    info("Non ci sono messaggi ricevuti dall'utente [" + utenteSelezionato + "]");
                }
                else
                {
                    //generareport(linee)
                    Resoconto form = new Resoconto(linee);
                    form.ShowDialog();
                }
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl1.SelectedTab.Text)
            {
                case "Online":
                    inviaMessaggio.Enabled = true;
                    inviaTutti.Enabled = true;
                    
                    break;
                case "Offline":
                    inviaMessaggio.Enabled = false;
                    inviaTutti.Enabled = false;
                    break;
            }
        }
    }
}

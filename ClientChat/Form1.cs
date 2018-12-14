using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientChat
{
    public partial class Form1 : Form
    {
        TcpClient cliente;
        public Form1()
        {
            InitializeComponent();
        }
        private void controlla()
        {
            if(ipServer.Text=="" || portaServer.Text == "" || nomeUtente.Text == "")
            {
                throw new Exception("Compila tutti i campi");
            }
            else if(nomeUtente.Text.Length>15)
            {
                throw new Exception("Nome troppo lungo");
            }
        }

        private void conferma_Click(object sender, EventArgs e)
        {
            if(cliente == null)
                cliente = new TcpClient();

            NetworkStream stream;
            int porta = Convert.ToInt32(portaServer.Text);
            string nome_server = ipServer.Text;
            string id="";

            try
            {
                Byte[] bytes;

                int numero_bytes;

                controlla();
                if (!cliente.Connected)
                {
                    try
                    {
                        cliente.Connect(nome_server, porta);
                    }
                    catch
                    {
                        throw new Exception("Server non raggiungibile");
                    }
                    stream = cliente.GetStream();

                    if (!stream.CanRead)
                    {
                        throw new Exception("Non posso leggere dallo Stream");
                    }
                    else
                        if (!stream.CanWrite)
                    {
                        throw new Exception("Non posso scrivere nello Stream");
                    }
                    bytes = new Byte[cliente.ReceiveBufferSize];

                    


                    numero_bytes = stream.Read(bytes, 0, cliente.ReceiveBufferSize);

                    id = Encoding.ASCII.GetString(bytes, 0, numero_bytes);
                }
                bytes = new Byte[cliente.ReceiveBufferSize];

               
                stream = cliente.GetStream();
                String stringa_inviata;
                String stringa_ricevuta;


                stringa_inviata = "N" + nomeUtente.Text;
                Byte[] bytes_da_inviare = Encoding.ASCII.GetBytes(stringa_inviata);
                stream.Write(bytes_da_inviare, 0, bytes_da_inviare.Length);

                numero_bytes = stream.Read(bytes, 0, cliente.ReceiveBufferSize);

                stringa_ricevuta = Encoding.ASCII.GetString(bytes, 0, numero_bytes);
                if (stringa_ricevuta == "N")
                {
                   
                    throw new Exception("Nome utente non valido!");
                }
                else
                {
                    
                    Chat chat = new Chat(cliente,nomeUtente.Text,id);
                    chat.Show();
                    this.Hide();
                    
                }



            }
            catch (Exception eccezione)
            {
                MessageBox.Show(eccezione.Message, "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

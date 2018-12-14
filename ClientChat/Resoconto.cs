using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientChat
{
    public partial class Resoconto : Form
    {
        public Resoconto()
        {
            InitializeComponent();
        }
        public Resoconto(List<Tuple<string, HorizontalAlignment>> linee)
        {
            
            InitializeComponent();
            //chat.Lines = linee.ToArray();
            foreach(Tuple<string, HorizontalAlignment> linea in linee)
            {
                chat.Select(chat.TextLength, 0);


                chat.SelectionAlignment = linea.Item2;  
                chat.SelectedRtf = linea.Item1;
                chat.AppendText(Environment.NewLine);
                
                
                    
            }
            //chat.Rtf = appo;

        }

        private void chiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

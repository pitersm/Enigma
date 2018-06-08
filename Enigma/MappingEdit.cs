using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    public partial class MappingEdit : Form
    {
        private Enigma enigma;

        public MappingEdit()
        {
            InitializeComponent();
        }

        public MappingEdit(Enigma enigma)
        {
            InitializeComponent();
            this.enigma = enigma;
        }

        private void MappingEdit_Load(object sender, EventArgs e)
        {

        }
    }
}

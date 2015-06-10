using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reports.Moviments
{
    public partial class MovimentsReport : Form
    {
        private MovimentType _movimentType;

        public MovimentsReport(MovimentType movimentType)
        {
            _movimentType = movimentType;

            InitializeComponent();
        }

        private void MovimentsReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryManagerDataSet1.MovimentsView' table. You can move, or remove it, as needed.
            
            this.movimentsViewTableAdapter1.Fill(this.inventoryManagerDataSet1.MovimentsView, _movimentType.ToString());
            // TODO: This line of code loads data into the 'inventoryManagerDataSet.MovimentsView' table. You can move, or remove it, as needed.
            //this.movimentsViewTableAdapter.Fill(this.inventoryManagerDataSet.MovimentsView);

            this.reportViewer1.RefreshReport();
        }
    }
}

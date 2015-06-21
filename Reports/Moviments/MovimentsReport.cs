using Domain;
using System;
using System.Windows.Forms;

namespace Reports.Moviments
{
    public partial class MovimentsReport : Form
    {
        private MovimentType _movimentType;
        private DateTime _initialDate;
        private DateTime _finalDate;

        public MovimentsReport(MovimentType movimentType, DateTime? initialDate = null, DateTime? finalDate = null)
        {
            _movimentType = movimentType;

            _initialDate = initialDate.HasValue ? initialDate.Value : DateTime.Now;

            _finalDate = finalDate.HasValue ? finalDate.Value : DateTime.Now;

            InitializeComponent();
        }

        private void MovimentsReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryManagerDataSet1.MovimentsView' table. You can move, or remove it, as needed.
            
            this.movimentsViewTableAdapter1.Fill(this.inventoryManagerDataSet1.MovimentsView, _movimentType.ToString(), _initialDate, _finalDate);
            // TODO: This line of code loads data into the 'inventoryManagerDataSet.MovimentsView' table. You can move, or remove it, as needed.
            //this.movimentsViewTableAdapter.Fill(this.inventoryManagerDataSet.MovimentsView);

            this.reportViewer1.RefreshReport();
        }
    }
}

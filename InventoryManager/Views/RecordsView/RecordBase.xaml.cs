using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManager.Views.Records
{
    /// <summary>
    /// Interaction logic for RecordBase.xaml
    /// </summary>
    public partial class RecordBase : UserControl
    {
        public RecordBase()
        {           
            
            InitializeComponent();
        }

        public DataGrid A
        {
            get { return (DataGrid)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, A); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("A", typeof(DataGrid),
              typeof(RecordBase), new FrameworkPropertyMetadata(default(DataGrid),
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public String Label
        {
            get { return (String)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string),
              typeof(RecordBase), new PropertyMetadata(""));
    }
}

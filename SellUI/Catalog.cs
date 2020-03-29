using System.Data.Entity;
using System.Windows.Forms;

namespace SellUI
{
    public partial class Catalog<T>: Form
        where T:class
    {
        public Catalog(DbSet<T> set)
        {
            InitializeComponent();
            dataGridView.DataSource = set.Local.ToBindingList();
        }
    }
}

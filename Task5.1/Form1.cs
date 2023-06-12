using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using Task5._1.Models;
using Microsoft.Data.SqlClient;

namespace Task5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new ProductContext())
            {
                var category = new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = textBox1.Text,
                    Icon = textBox2.Text
                };
                context.Categories.Add(category);
                context.SaveChanges();
            }
            MessageBox.Show($"{textBox1.Text} added to Category");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new ProductContext())
            {
                var products = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = textBox3.Text,
                    Price = Convert.ToDouble(textBox4.Text),
                    ActionPrice = Convert.ToDouble(textBox5.Text),
                    Description = textBox6.Text,
                    DescriptionField1 = textBox7.Text,
                    DescriptionField2 = textBox8.Text,
                    ImageUrl = textBox9.Text,
                    Category = new Category()
                    {
                        Name = textBox10.Text,
                        Icon = textBox10.Text
                    },
                    Carts = new List<Cart>(new Cart[]
                    {
                        new Cart()
                        {
                            UsersUser = new User()
                            {
                                Name = textBox11.Text,
                                Login = textBox12.Text,
                                Password = textBox13.Text,
                                Email = textBox14.Text
                            }
                        }
                    }),
                    KeyParams = new List<KeyParam>(new KeyParam[]
                    {
                        new KeyParam()
                        {
                            KeyWords = new Word()
                            {
                                Header = textBox15.Text,
                                KeyWord = textBox16.Text
                            }
                        }
                    })
                };
                context.Products.Add(products);
                context.SaveChanges();
            }
            MessageBox.Show($"{textBox3.Text} added to Products");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new ProductContext())
            {
                var keyWords = new Word()
                {
                    Id = Guid.NewGuid(),
                    Header = textBox17.Text,
                    KeyWord = textBox18.Text,
                };
                context.Words.Add(keyWords);
                context.SaveChanges();
            }
            MessageBox.Show($"{textBox17.Text} added to Words");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Choose the place for saving";
                saveFileDialog.Filter = "Backup files (*.bak)|*.bak|All files (*.*)|*.*";
                DialogResult result = saveFileDialog.ShowDialog();
                if(result == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string backupDatabaseSql = $"BACKUP DATABASE Product TO DISK = '{filePath}'";
                    using(ProductContext context = new ProductContext())
                    {
                        context.Database.ExecuteSqlRaw(backupDatabaseSql);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        string backupFilePath = openFileDialog.FileName;
                        string restoreQuery = $"RESTORE DATABASE Product FROM DISK = '{backupFilePath}' WITH REPLACE";
                        using (ProductContext context = new ProductContext())
                        {
                            context.Database.ExecuteSqlRaw("ALTER DATABASE Product SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                            context.Database.ExecuteSqlRaw(restoreQuery);
                        }
                        MessageBox.Show("Database restored successfully!");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error restoring database: " + ex.Message);
                    }
                    
                }
            }
        }
    }
}
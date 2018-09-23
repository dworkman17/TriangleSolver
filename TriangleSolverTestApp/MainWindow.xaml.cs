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
using TriangleSolver;


namespace TriangleSolverTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcByCoords_Click(object sender, RoutedEventArgs e)
        {
            string xValue = "";
            int yValue = 0;

            try
            {
                xValue = txtXValue.Text;
                yValue = System.Convert.ToInt32(txtYValue.Text);

            }
            catch (Exception)
            {
                tblkResult.Text = "Failed to convert y value to the proper format, check your inputs.";
                return;
            }

            Triangle testTri = new Triangle();
            try
            {
                testTri = new Triangle(xValue, yValue);
            }
            catch (Exception ex)
            {
                tblkResult.Text = ex.Message;
                return;
            }

            tblkResult.Text =  testTri.ToString();



        }

        private void btnCalcByVertices_Click(object sender, RoutedEventArgs e)
        {
            int vx1 = 0;
            int vy1 = 0;

            int vx2 = 0;
            int vy2 = 0;

            int vx3 = 0;
            int vy3 = 0;

            try
            {
                string[] v1 = txtV1.Text.Split(',');
                vx1 = System.Convert.ToInt32(v1[0].Trim());
                vy1 = System.Convert.ToInt32(v1[1].Trim());

                string[] v2 = txtV2.Text.Split(',');
                vx2 = System.Convert.ToInt32(v2[0].Trim());
                vy2 = System.Convert.ToInt32(v2[1].Trim());

                string[] v3 = txtV3.Text.Split(',');
                vx3 = System.Convert.ToInt32(v3[0].Trim());
                vy3 = System.Convert.ToInt32(v3[1].Trim());


            }
            catch (Exception)
            {
                tblkResult.Text =  "Failed to convert input into a vertex format (x,y). Coords must be comma separated.";
                return;
            }

            Triangle testTri = new Triangle();
            try
            {
                testTri = new Triangle(vx1, vy1, vx2, vy2, vx3, vy3);
            } catch (Exception ex)
            {
                tblkResult.Text = ex.Message;
                return;
            }
            

            tblkResult.Text = testTri.ToString();


        }

    }
}

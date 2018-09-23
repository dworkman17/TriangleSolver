using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleSolver;

namespace TriangleSolverTests
{
    [TestClass]
    public class TriangleTests
    {
        #region " Contructor Input Tests "

        [TestMethod]
        public void Triangle_ByCoordsConstructor_HasAllParams_Succeeds()
        {
            Triangle test = new Triangle("A", 1);

            Assert.IsNotNull(test);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Triangle_ByCoordsConstructor_MissingRow_ThrowsException()
        {
            Triangle test = new Triangle(null, 1);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Triangle_ByCoordsConstructor_MissingCol_ThrowsException()
        {
            Triangle test = new Triangle("A", null);

        }
        
        [TestMethod]
        public void Triangle_ByVerticesConstructor_HasAllParams_Succeeds()
        {
            Triangle test = new Triangle(0, 10, 0,0, 10, 10);

            Assert.IsNotNull(test);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Triangle_ByVerticesConstructor_vx1_ThrowsException()
        {
            Triangle test = new Triangle(null, 1,1,1,1,1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Triangle_ByVerticesConstructor_vy1_ThrowsException()
        {
            Triangle test = new Triangle(1, null, 1, 1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Triangle_ByVerticesConstructor_vx2_ThrowsException()
        {
            Triangle test = new Triangle(1, 1, null, 1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Triangle_ByVerticesConstructor_vy2_ThrowsException()
        {
            Triangle test = new Triangle(1, 1, 1, null, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Triangle_ByVerticesConstructor_vx3_ThrowsException()
        {
            Triangle test = new Triangle(1, 1, 1, 1, null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Triangle_ByVerticesConstructor_vy3_ThrowsException()
        {
            Triangle test = new Triangle(1, 1, 1, 1, 1, null);
        }

        #endregion

        #region " Output Tests - By Coords "

        // Picked a handful of possible options (not quite half of all possible triangles) as test cases. 
        // Covered the corners to make sure edge cases are good... 


        // A1, A2, A11, A12
        [TestMethod]
        public void Triangle_ByCoords_A1_VerticesAreCorrect()
        {
            Triangle test = new Triangle("A", 1);

            Assert.AreEqual(test.V1, "(0,10)");
            Assert.AreEqual(test.V2, "(0,0)");
            Assert.AreEqual(test.V3, "(10,10)");
        }
        [TestMethod]
        public void Triangle_ByCoords_A2_VerticesAreCorrect()
        {
            Triangle test = new Triangle("A", 2);

            Assert.AreEqual(test.V1, "(10,0)");
            Assert.AreEqual(test.V2, "(0,0)");
            Assert.AreEqual(test.V3, "(10,10)");
        }
        [TestMethod]
        public void Triangle_ByCoords_A11_VerticesAreCorrect()
        {
            Triangle test = new Triangle("A", 11);

            Assert.AreEqual(test.V1, "(50,10)");
            Assert.AreEqual(test.V2, "(50,0)");
            Assert.AreEqual(test.V3, "(60,10)");
        }
        [TestMethod]
        public void Triangle_ByCoords_A12_VerticesAreCorrect()
        {
            Triangle test = new Triangle("A", 12);

            Assert.AreEqual(test.V1, "(60,0)");
            Assert.AreEqual(test.V2, "(50,0)");
            Assert.AreEqual(test.V3, "(60,10)");
        }

        // B1, B2, B5, B6
        [TestMethod]
        public void Triangle_ByCoords_B1_VerticesAreCorrect()
        {
            Triangle test = new Triangle("B", 1);

            Assert.AreEqual(test.V1, "(0,20)");
            Assert.AreEqual(test.V2, "(0,10)");
            Assert.AreEqual(test.V3, "(10,20)");
        }
        [TestMethod]
        public void Triangle_ByCoords_B2_VerticesAreCorrect()
        {
            Triangle test = new Triangle("B", 2);

            Assert.AreEqual(test.V1, "(10,10)");
            Assert.AreEqual(test.V2, "(0,10)");
            Assert.AreEqual(test.V3, "(10,20)");
        }
        [TestMethod]
        public void Triangle_ByCoords_B5_VerticesAreCorrect()
        {
            Triangle test = new Triangle("B", 5);

            Assert.AreEqual(test.V1, "(20,20)");
            Assert.AreEqual(test.V2, "(20,10)");
            Assert.AreEqual(test.V3, "(30,20)");
        }
        [TestMethod]
        public void Triangle_ByCoords_B6_VerticesAreCorrect()
        {
            Triangle test = new Triangle("B", 6);

            Assert.AreEqual(test.V1, "(30,10)");
            Assert.AreEqual(test.V2, "(20,10)");
            Assert.AreEqual(test.V3, "(30,20)");
        }

        // C1, C2, C7, C8
        [TestMethod]
        public void Triangle_ByCoords_C1_VerticesAreCorrect()
        {
            Triangle test = new Triangle("C", 1);

            Assert.AreEqual(test.V1, "(0,30)");
            Assert.AreEqual(test.V2, "(0,20)");
            Assert.AreEqual(test.V3, "(10,30)");
        }
        [TestMethod]
        public void Triangle_ByCoords_C2_VerticesAreCorrect()
        {
            Triangle test = new Triangle("C", 2);

            Assert.AreEqual(test.V1, "(10,20)");
            Assert.AreEqual(test.V2, "(0,20)");
            Assert.AreEqual(test.V3, "(10,30)");
        }
        [TestMethod]
        public void Triangle_ByCoords_C7_VerticesAreCorrect()
        {
            Triangle test = new Triangle("C", 7);

            Assert.AreEqual(test.V1, "(30,30)");
            Assert.AreEqual(test.V2, "(30,20)");
            Assert.AreEqual(test.V3, "(40,30)");
        }
        [TestMethod]
        public void Triangle_ByCoords_C8_VerticesAreCorrect()
        {
            Triangle test = new Triangle("C", 8);

            Assert.AreEqual(test.V1, "(40,20)");
            Assert.AreEqual(test.V2, "(30,20)");
            Assert.AreEqual(test.V3, "(40,30)");
        }

        // D1, D2, D9, D10
        [TestMethod]
        public void Triangle_ByCoords_D1_VerticesAreCorrect()
        {
            Triangle test = new Triangle("D", 1);

            Assert.AreEqual(test.V1, "(0,40)");
            Assert.AreEqual(test.V2, "(0,30)");
            Assert.AreEqual(test.V3, "(10,40)");
        }
        [TestMethod]
        public void Triangle_ByCoords_D2_VerticesAreCorrect()
        {
            Triangle test = new Triangle("D", 2);

            Assert.AreEqual(test.V1, "(10,30)");
            Assert.AreEqual(test.V2, "(0,30)");
            Assert.AreEqual(test.V3, "(10,40)");
        }
        [TestMethod]
        public void Triangle_ByCoords_D9_VerticesAreCorrect()
        {
            Triangle test = new Triangle("D", 9);

            Assert.AreEqual(test.V1, "(40,40)");
            Assert.AreEqual(test.V2, "(40,30)");
            Assert.AreEqual(test.V3, "(50,40)");
        }
        [TestMethod]
        public void Triangle_ByCoords_D10_VerticesAreCorrect()
        {
            Triangle test = new Triangle("D", 10);

            Assert.AreEqual(test.V1, "(50,30)");
            Assert.AreEqual(test.V2, "(40,30)");
            Assert.AreEqual(test.V3, "(50,40)");
        }

        // E1, E2, E11, E12
        [TestMethod]
        public void Triangle_ByCoords_E1_VerticesAreCorrect()
        {
            Triangle test = new Triangle("E", 1);

            Assert.AreEqual(test.V1, "(0,50)");
            Assert.AreEqual(test.V2, "(0,40)");
            Assert.AreEqual(test.V3, "(10,50)");
        }
        [TestMethod]
        public void Triangle_ByCoords_E2_VerticesAreCorrect()
        {
            Triangle test = new Triangle("E", 2);

            Assert.AreEqual(test.V1, "(10,40)");
            Assert.AreEqual(test.V2, "(0,40)");
            Assert.AreEqual(test.V3, "(10,50)");
        }
        [TestMethod]
        public void Triangle_ByCoords_E11_VerticesAreCorrect()
        {
            Triangle test = new Triangle("E", 11);

            Assert.AreEqual(test.V1, "(50,50)");
            Assert.AreEqual(test.V2, "(50,40)");
            Assert.AreEqual(test.V3, "(60,50)");
        }
        [TestMethod]
        public void Triangle_ByCoords_E12_VerticesAreCorrect()
        {
            Triangle test = new Triangle("E", 12);

            Assert.AreEqual(test.V1, "(60,40)");
            Assert.AreEqual(test.V2, "(50,40)");
            Assert.AreEqual(test.V3, "(60,50)");
        }

        // F1, F2, F11, F12
        [TestMethod]
        public void Triangle_ByCoords_F1_VerticesAreCorrect()
        {
            Triangle test = new Triangle("F", 1);

            Assert.AreEqual(test.V1, "(0,60)");
            Assert.AreEqual(test.V2, "(0,50)");
            Assert.AreEqual(test.V3, "(10,60)");
        }
        [TestMethod]
        public void Triangle_ByCoords_F2_VerticesAreCorrect()
        {
            Triangle test = new Triangle("F", 2);

            Assert.AreEqual(test.V1, "(10,50)");
            Assert.AreEqual(test.V2, "(0,50)");
            Assert.AreEqual(test.V3, "(10,60)");
        }
        [TestMethod]
        public void Triangle_ByCoords_F11_VerticesAreCorrect()
        {
            Triangle test = new Triangle("F", 11);

            Assert.AreEqual(test.V1, "(50,60)");
            Assert.AreEqual(test.V2, "(50,50)");
            Assert.AreEqual(test.V3, "(60,60)");
        }
        [TestMethod]
        public void Triangle_ByCoords_F12_VerticesAreCorrect()
        {
            Triangle test = new Triangle("F", 12);

            Assert.AreEqual(test.V1, "(60,50)"); 
            Assert.AreEqual(test.V2, "(50,50)");
            Assert.AreEqual(test.V3, "(60,60)");
        }

        #endregion

        #region " Output Tests - By Vertices "
        // Picked a handful of possible options (not quite half of all possible triangles) as test cases. 
        // Covered the corners to make sure edge cases are good... 


        // A1, A2, A11, A12
        [TestMethod]
        public void Triangle_ByVertices_A1_CoordsAreCorrect()
        {            
            Triangle test = new Triangle(0,10,0,0,10,10);
        
            //Assert.AreEqual(test.V1, "(0,10)");
            //Assert.AreEqual(test.V2, "(0,0)");
            //Assert.AreEqual(test.V3, "(10,10)");

            Assert.AreEqual(test.Row, "A");
            Assert.AreEqual(test.Column, "1");

        }
        [TestMethod]
        public void Triangle_ByVertices_A2_CoordsAreCorrect()
        {
            Triangle test = new Triangle(10,0,0,0,10,10);

            //Assert.AreEqual(test.V1, "(10,0)");
            //Assert.AreEqual(test.V2, "(0,0)");
            //Assert.AreEqual(test.V3, "(10,10)");

            Assert.AreEqual(test.Row, "A");
            Assert.AreEqual(test.Column, "2");
        }
        [TestMethod]
        public void Triangle_ByVertices_A11_CoordsAreCorrect()
        {
            Triangle test = new Triangle(50,10,50,0,60,10);

            //Assert.AreEqual(test.V1, "(50,10)");
            //Assert.AreEqual(test.V2, "(50,0)");
            //Assert.AreEqual(test.V3, "(60,10)");

            Assert.AreEqual(test.Row, "A");
            Assert.AreEqual(test.Column, "11");
        }
        [TestMethod]
        public void Triangle_ByVertices_A12_CoordsAreCorrect()
        {
            Triangle test = new Triangle(60,0,50,0,60,10);

            //Assert.AreEqual(test.V1, "(60,0)");
            //Assert.AreEqual(test.V2, "(50,0)");
            //Assert.AreEqual(test.V3, "(60,10)");

            Assert.AreEqual(test.Row, "A");
            Assert.AreEqual(test.Column, "12");
        }

        // B1, B2, B5, B6
        [TestMethod]
        public void Triangle_ByVertices_B1_CoordsAreCorrect()
        {
            Triangle test = new Triangle(0,20,0,10,10,20);

            //Assert.AreEqual(test.V1, "(0,20)");
            //Assert.AreEqual(test.V2, "(0,10)");
            //Assert.AreEqual(test.V3, "(10,20)");

            Assert.AreEqual(test.Row, "B");
            Assert.AreEqual(test.Column, "1");
        }
        [TestMethod]
        public void Triangle_ByVertices_B2_CoordsAreCorrect()
        {
            Triangle test = new Triangle(10,10,0,10,10,20);

            //Assert.AreEqual(test.V1, "(10,10)");
            //Assert.AreEqual(test.V2, "(0,10)");
            //Assert.AreEqual(test.V3, "(10,20)");

            Assert.AreEqual(test.Row, "B");
            Assert.AreEqual(test.Column, "2");
        }
        [TestMethod]
        public void Triangle_ByVertices_B5_CoordsAreCorrect()
        {
            Triangle test = new Triangle(20,20,20,10,30,20);

            //Assert.AreEqual(test.V1, "(20,20)");
            //Assert.AreEqual(test.V2, "(20,10)");
            //Assert.AreEqual(test.V3, "(30,20)");
            
            Assert.AreEqual(test.Row, "B");
            Assert.AreEqual(test.Column, "5");
        }
        [TestMethod]
        public void Triangle_ByVertices_B6_CoordsAreCorrect()
        {
            Triangle test = new Triangle(30,10,20,10,30,20);

            //Assert.AreEqual(test.V1, "(30,10)");
            //Assert.AreEqual(test.V2, "(20,10)");
            //Assert.AreEqual(test.V3, "(30,20)");

            Assert.AreEqual(test.Row, "B");
            Assert.AreEqual(test.Column, "6");
        }

        // C1, C2, C7, C8
        [TestMethod]
        public void Triangle_ByVertices_C1_CoordsAreCorrect()
        {
            Triangle test = new Triangle(0,30,0,20,10,30);

            //Assert.AreEqual(test.V1, "(0,30)");
            //Assert.AreEqual(test.V2, "(0,20)");
            //Assert.AreEqual(test.V3, "(10,30)");

            Assert.AreEqual(test.Row, "C");
            Assert.AreEqual(test.Column, "1");
        }
        [TestMethod]
        public void Triangle_ByVertices_C2_CoordsAreCorrect()
        {
            Triangle test = new Triangle(10,20,0,20,10,30);

            //Assert.AreEqual(test.V1, "(10,20)");
            //Assert.AreEqual(test.V2, "(0,20)");
            //Assert.AreEqual(test.V3, "(10,30)");

            Assert.AreEqual(test.Row, "C");
            Assert.AreEqual(test.Column, "2");
        }
        [TestMethod]
        public void Triangle_ByVertices_C7_CoordsAreCorrect()
        {
            Triangle test = new Triangle(30,30,30,20,40,30);

            //Assert.AreEqual(test.V1, "(30,30)");
            //Assert.AreEqual(test.V2, "(30,20)");
            //Assert.AreEqual(test.V3, "(40,30)");

            Assert.AreEqual(test.Row, "C");
            Assert.AreEqual(test.Column, "7");
        }
        [TestMethod]
        public void Triangle_ByVertices_C8_CoordsAreCorrect()
        {
            Triangle test = new Triangle(40,20,30,20,40,30);

            //Assert.AreEqual(test.V1, "(40,20)");
            //Assert.AreEqual(test.V2, "(30,20)");
            //Assert.AreEqual(test.V3, "(40,30)");

            Assert.AreEqual(test.Row, "C");
            Assert.AreEqual(test.Column, "8");
        }

        // D1, D2, D9, D10
        [TestMethod]
        public void Triangle_ByVertices_D1_CoordsAreCorrect()
        {
            Triangle test = new Triangle(0,40,0,30,10,40);

            //Assert.AreEqual(test.V1, "(0,40)");
            //Assert.AreEqual(test.V2, "(0,30)");
            //Assert.AreEqual(test.V3, "(10,40)");

            Assert.AreEqual(test.Row, "D");
            Assert.AreEqual(test.Column, "1");
        }
        [TestMethod]
        public void Triangle_ByVertices_D2_CoordsAreCorrect()
        {
            Triangle test = new Triangle(10,30,0,30,10,40);

            //Assert.AreEqual(test.V1, "(10,30)");
            //Assert.AreEqual(test.V2, "(0,30)");
            //Assert.AreEqual(test.V3, "(10,40)");

            Assert.AreEqual(test.Row, "D");
            Assert.AreEqual(test.Column, "2");
        }
        [TestMethod]
        public void Triangle_ByVertices_D9_CoordsAreCorrect()
        {
            Triangle test = new Triangle(40,40,40,30,50,40);

            //Assert.AreEqual(test.V1, "(40,40)");
            //Assert.AreEqual(test.V2, "(40,30)");
            //Assert.AreEqual(test.V3, "(50,40)");

            Assert.AreEqual(test.Row, "D");
            Assert.AreEqual(test.Column, "9");
        }
        [TestMethod]
        public void Triangle_ByVertices_D10_CoordsAreCorrect()
        {
            Triangle test = new Triangle(50,30,40,30,50,40);

            //Assert.AreEqual(test.V1, "(50,30)");
            //Assert.AreEqual(test.V2, "(40,30)");
            //Assert.AreEqual(test.V3, "(50,40)");

            Assert.AreEqual(test.Row, "D");
            Assert.AreEqual(test.Column, "10");
        }
        
        // E1, E2, E11, E12
        [TestMethod]
        public void Triangle_ByVertices_E1_CoordsAreCorrect()
        {
            Triangle test = new Triangle(0,50,0,40,10,50);

            //Assert.AreEqual(test.V1, "(0,50)");
            //Assert.AreEqual(test.V2, "(0,40)");
            //Assert.AreEqual(test.V3, "(10,50)");

            Assert.AreEqual(test.Row, "E");
            Assert.AreEqual(test.Column, "1");
        }
        [TestMethod]
        public void Triangle_ByVertices_E2_CoordsAreCorrect()
        {
            Triangle test = new Triangle(10,40,0,40,10,50);

            //Assert.AreEqual(test.V1, "(10,40)");
            //Assert.AreEqual(test.V2, "(0,40)");
            //Assert.AreEqual(test.V3, "(10,50)");

            Assert.AreEqual(test.Row, "E");
            Assert.AreEqual(test.Column, "2");
        }
        [TestMethod]
        public void Triangle_ByVertices_E11_CoordsAreCorrect()
        {
            Triangle test = new Triangle(50,50,50,40,60,50);

            //Assert.AreEqual(test.V1, "(50,50)");
            //Assert.AreEqual(test.V2, "(50,40)");
            //Assert.AreEqual(test.V3, "(60,50)");

            Assert.AreEqual(test.Row, "E");
            Assert.AreEqual(test.Column, "11");
        }
        [TestMethod]
        public void Triangle_ByVertices_E12_CoordsAreCorrect()
        {
            Triangle test = new Triangle(60,40,50,40,60,50);

            //Assert.AreEqual(test.V1, "(60,40)");
            //Assert.AreEqual(test.V2, "(50,40)");
            //Assert.AreEqual(test.V3, "(60,50)");

            Assert.AreEqual(test.Row, "E");
            Assert.AreEqual(test.Column, "12");
        }

        // F1, F2, F11, F12
        [TestMethod]
        public void Triangle_ByVertices_F1_CoordsAreCorrect()
        {
            Triangle test = new Triangle(0,60,0,50,10,60);

            //Assert.AreEqual(test.V1, "(0,60)");
            //Assert.AreEqual(test.V2, "(0,50)");
            //Assert.AreEqual(test.V3, "(10,60)");

            Assert.AreEqual(test.Row, "F");
            Assert.AreEqual(test.Column, "1");
        }
        [TestMethod]
        public void Triangle_ByVertices_F2_CoordsAreCorrect()
        {
            Triangle test = new Triangle(10,50,0,50,10,60);

            //Assert.AreEqual(test.V1, "(10,50)");
            //Assert.AreEqual(test.V2, "(0,50)");
            //Assert.AreEqual(test.V3, "(10,60)");

            Assert.AreEqual(test.Row, "F");
            Assert.AreEqual(test.Column, "2");
        }
        [TestMethod]
        public void Triangle_ByVertices_F11_CoordsAreCorrect()
        {
            Triangle test = new Triangle(50,60,50,50,60,60);

            //Assert.AreEqual(test.V1, "(50,60)");
            //Assert.AreEqual(test.V2, "(50,50)");
            //Assert.AreEqual(test.V3, "(60,60)");

            Assert.AreEqual(test.Row, "F");
            Assert.AreEqual(test.Column, "11");
        }
        [TestMethod]
        public void Triangle_ByVertices_F12_CoordsAreCorrect()
        {
            Triangle test = new Triangle(60,50,50,50,60,60);

            //Assert.AreEqual(test.V1, "(60,50)");
            //Assert.AreEqual(test.V2, "(50,50)");
            //Assert.AreEqual(test.V3, "(60,60)");

            Assert.AreEqual(test.Row, "F");
            Assert.AreEqual(test.Column, "12");
        }

        #endregion

        #region " Fail Cases "
        [TestMethod]
        [ExpectedException(typeof(Exception), "The vertices entered do not create a valid triangle.")]
        public void Triangle_ByVertices_CoordsCreateInvalidTriangle_ThrowsException()
        {
            Triangle test = new Triangle(10, 10, 10, 10, 10, 10);
            
        }


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSolver
{
    public class Triangle
            {



        /*
         * Triangle vertices as follows:
         * 
         *     v2               v2  ----- v1   
         *      |\                  \   |
         *      | \        or        \  |
         *      |  \                  \ |
         *      |   \                  \|
         *   v1 ----- v3                v3
         */

        #region " Member vars and properties "

            // these vars represent the "triangle ID" such as A1 or D5
        private string mTriangleRow;
        private int mTriangleCol;

        //these base values will be used to calculate the vertex coords
        //(mRowBase, mColBase) is the upper left most vertex, the rest are calculated from that
        //based on if the column is odd (for lower triangles) or even (for upper triangles)
        private int? mRowBase;
            private int? mColBase;

            //v2 is the non-right angle vertex in the upper left
            private int? mvx2;
            private int? mvy2;

            //v1 is the right angle vertex
            private int? mvx1;
            private int? mvy1;

            //v3 is the non-right angle vertex in the lower right
            private int? mvx3;
            private int? mvy3;

        public string Row
        {
            get
            {
                return mTriangleRow;
            }
        }

        public string Column
        {
            get
            {
                return mTriangleCol.ToString();
            }
        }

            public string V1
            {
                get {
                    return "(" + mvx1 + "," + mvy1 + ")";
                    }
            }

            public string V2
            {
                get
                {
                    return "(" + mvx2 + "," + mvy2 + ")";
                }
            }

            public string V3
            {
                get
                {
                    return "(" + mvx3 + "," + mvy3 + ")";
                }
            }

        #endregion

        #region " Generic Functionality "

            public Triangle()
            {

            }

            public override string ToString()
            {
                return String.Format(@"Triangle {0}{1} has the following vertices: 
                        V1 {2} 
                        V2 {3}
                        V3 {4}"
                        , Row, Column, V1, V2, V3);
            }

            public override bool Equals(object obj)
            {
                var item = obj as Triangle;

                if (V1 == item.V1 && V2 == item.V2 && V3 == item.V3)
                {
                    return true;
                }

                return false;
            }

            public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        #endregion-

        #region " Triangle from Coords "

        public Triangle(string row, int? col)
        {

            if (row == null)
            {
                throw new ArgumentNullException("Row is required by the triangle constructor.");
            }

            if (!col.HasValue)
            {
                throw new ArgumentNullException("Col is required by the triangle constructor.");
            }

            mTriangleRow = (string)row;
            mTriangleCol = (int)col;

            //set the upper right vertex coords
            mRowBase = SetTriangleRowBaseValue(mTriangleRow);
            mColBase = SetTriangleColBaseValue(mTriangleCol);

            mvx2 = mColBase;
            mvy2 = mRowBase;

            try
            {
                CalculateLowerRightVertexCoords();
                CalculateRightAngleVertexCoord();
            } catch (Exception ex)
            {
                throw ex;
            }
            
        }

        int SetTriangleRowBaseValue(string row)
        {
            switch (row.ToUpper())
            {
                case "A":
                    return 0;
                case "B":
                    return 10;
                case "C":
                    return 20;
                case "D":
                    return 30;
                case "E":
                    return 40;
                case "F":
                    return 50;
                default:
                    throw new Exception("Invalid row.");
            }

        }

        int SetTriangleColBaseValue(int col)
        {
            //going to divide by two because we just need one base value per column of two triangles
            double temp = ((double)col / 2);

            switch ((int)Math.Ceiling(temp))
            {
                case 1: // row 1 or 2
                    return 0;
                case 2: // row 3 or 4
                    return 10;
                case 3: // row 5 or 6
                    return 20;
                case 4: // row 7 or 8
                    return 30;
                case 5: // row 9 or 10
                    return 40;
                case 6: // row 11 or 12
                    return 50;
                default:
                    throw new Exception("Invalid column.");
            }

        }
                    
        // this function takes the base coords (upper left vertex) and figures out the other non-right angle vertex (lower right)
        void CalculateLowerRightVertexCoords()
        {

            if (!mRowBase.HasValue || !mColBase.HasValue)
            {
                throw new Exception("Failed to calculate base vertex. Unable to calculate vertex.");
            }
            else
            {
                //mvy2 = mColBase;

                //decimal tempvx1 = ((decimal)mRowBase - 1) / 2;
                //mvy2 = (int)Math.Floor(tempvx1);

                mvx3 = mColBase + 10;
                mvy3 = mRowBase + 10;

            }
        }

        //this function will calculate the coords of the right-angle vertex, assuming the other two are already set
        void CalculateRightAngleVertexCoord()
        {
            if (!mRowBase.HasValue || !mColBase.HasValue)
            {
                throw new Exception("Failed to calculate base vertex. Unable to calculate vertex.");
            }
            else
            {
                int temp = ((int)mTriangleCol) % 2;
                if (mTriangleCol == 0 || temp == 1)
                {
                    mvx1 = mvx2;
                    mvy1 = mvy3;

                }
                else
                {
                    mvx1 = mvx3;
                    mvy1 = mvy2;
                }
            }

        }

        #endregion

        #region " Triangle from Vertices "

        public Triangle(int? vx1, int? vy1, int? vx2, int? vy2, int? vx3, int? vy3)
        {
            if (!vx1.HasValue)
            {
                throw new ArgumentNullException("vx1 is required by the triangle constructor.");
            }
            if (!vy1.HasValue)
            {
                throw new ArgumentNullException("vy1 is required by the triangle constructor.");
            }
            if (!vx2.HasValue)
            {
                throw new ArgumentNullException("vx2 is required by the triangle constructor.");
            }
            if (!vy2.HasValue)
            {
                throw new ArgumentNullException("vy2 is required by the triangle constructor.");
            }
            if (!vx3.HasValue)
            {
                throw new ArgumentNullException("vx3 is required by the triangle constructor.");
            }
            if (!vy3.HasValue)
            {
                throw new ArgumentNullException("vy3 is required by the triangle constructor.");
            }
            
            mvx1 = vx1;
            mvy1 = vy1;

            mvx2 = vx2;
            mvy2 = vy2;

            mvx3 = vx3;
            mvy3 = vy3;

            if (mvx1 % 10 != 0 || mvx2 % 10 != 0 || mvx3 % 10 != 0 || mvy1 % 10 != 0 || mvy2 % 10 != 0 || mvy3 % 10 != 0
                    || mvx1 > 60 || mvx2 > 60 || mvx3 > 60 || mvy1 > 60 || mvy2 > 60 || mvy3 > 60
                    || mvx1 < 0 || mvx2 < 0 || mvx3 < 0 || mvy1 < 0 || mvy2 < 0 || mvy3 < 0)
                {
                    throw new Exception("Coordinate must be a multiple of 10 between 0 and 60.");
                }

            mTriangleRow = CalculateRow();
            mTriangleCol = CalculateColumn();

            if (! IsTriangleByVerticesValid())
            {
                throw new Exception("The vertices entered do not create a valid triangle.");
            }

        }
        
        string CalculateRow()
        {
            switch (mvy2)
            {
                case 0:
                    return "A";
                case 10:
                    return "B";
                case 20:
                    return "C";
                case 30:
                    return "D";
                case 40:
                    return "E";
                case 50:
                    return "F";

                default:
                    throw new Exception("Failed calculating row from vertices.");
            }
        }

        int CalculateColumn()
        {
            return (int)((mvx1 + mvx3) / 10);
        }

        // this function checks the vertices to ensure they create a proper triangle
        public Boolean IsTriangleByVerticesValid()
        {
            try
            {
                // the triangle calcuated is based simply on the upper left corner vertex's y value (for row)
                // and the difference between the other two vertexes. 
                // if the coordinates themselves are valid, that doesn't mean they actually define a real triangle
                // to validate it, we will attempt to create a triangle at that location and compare
                // the vertices of the two triangles. 
                // if they match, then we know the vertices entered have created a valid triangle
                Triangle temp = new Triangle(mTriangleRow, mTriangleCol);

                if (Equals(temp))
                {
                    return true;
                }
            }
            catch
            {
            }

            return false;

        }
        #endregion


    }
}

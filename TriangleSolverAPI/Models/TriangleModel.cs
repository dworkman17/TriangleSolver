using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriangleSolverAPI.Models
{
    public class TriangleModel : TriangleSolver.Triangle
    {

        private TriangleSolver.Triangle mTriangle;

        public TriangleSolver.Triangle Triangle
        {
            get
            {
                return mTriangle;
            }
        }

        public TriangleModel(string row, int col)
        {
            TriangleSolver.Triangle temp = new TriangleSolver.Triangle(row, col);
            mTriangle = temp;
        }

        public TriangleModel(int? vx1, int? vy1, int? vx2, int? vy2, int? vx3, int? vy3)
        {
            TriangleSolver.Triangle temp = new TriangleSolver.Triangle(vx1,vy1,vx2,vy2,vx3,vy3);
            mTriangle = temp;
        }
    }
}
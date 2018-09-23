using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace TriangleSolverAPI.Controllers
{
    public class TriangleSolverController : ApiController
    {
        // example call: /api/trianglesolver/GetByCoords/?xValue=A&yValue=1
        public string GetByCoords([FromUri]string xValue, int yValue)
        {
            Models.TriangleModel temp = new Models.TriangleModel(xValue, yValue);

            return temp.Triangle.ToString();
        }

        ///example call: /api/trianglesolver/GetByVertices/?v1x=0&v1y=10&v2x=0&v2y=0&v3x=10&v3y=10
        public string GetByVertices([FromUri]int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
        {
            Models.TriangleModel temp = new Models.TriangleModel(v1x, v1y, v2x, v2y, v3x, v3y);

            return temp.Triangle.ToString();
        }

    }
}

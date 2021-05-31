/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2022
 * Email: venkat@pratian.com
 */

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG.CandidateProfiling.Data
{
    public class CandidateProfilingContext : DbContext
    {
        public CandidateProfilingContext(DbContextOptions options):base(options)
        {

        }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class OfferSpecifications : BaseSpecification<Offer>
    {
        public OfferSpecifications(int jobId) : base(x => x.JobId == jobId)
        {

        }
    }
}

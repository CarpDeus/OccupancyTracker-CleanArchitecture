using Sqids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Persistence.Models
{
    public class ParsedSqids
    {
        private SqidsEncoder<long> _sqidsEncoder = new SqidsEncoder<long>();

        public ParsedSqids(SqidsEncoder<long> sqidsEncoder)
        {
            _sqidsEncoder = sqidsEncoder;
        }

        public long? OrganizationId { get; set; }
        public long? LocationId { get; set; }
        public long? EntranceId { get; set; }
        public long? EntranceCounterId { get; set; }

        public string OrganizationSqid { get { return GenerateSqid((long)this.OrganizationId); } }
        public string LocationSqid { get { return GenerateSqid(this.OrganizationId, this.LocationId); } }
        public string EntranceSqid { get { return GenerateSqid(this.OrganizationId, this.LocationId, this.EntranceId); } }
        public string EntranceCounterSqid { get { return GenerateSqid(this.OrganizationId, this.LocationId, this.EntranceId, this.EntranceCounterId); } }

        private string GenerateSqid(params long?[] ids)
        {
            if (ids.Any(id => id == null))
            {
                return string.Empty;
            }
            long[] nonNullIds = ids.Select(id => (long)id).ToArray();
            return _sqidsEncoder.Encode(nonNullIds);
        }
    }
}

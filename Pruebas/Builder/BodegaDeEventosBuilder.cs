using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour.DDD.Domain.Generico;

namespace Pruebas.Builder
{
    public class BodegaDeEventosBuilder
    {
        private string _storedId;
        private string _storedName;
        private string _aggregateId;
        private string _eventBody;

        public BodegaDeEventosBuilder WithStoredId(string storedId)
        {
            _storedId = storedId;
            return this;
        }

        public BodegaDeEventosBuilder WithStoredName(string storedName)
        {
            _storedName = storedName;
            return this;
        }

        public BodegaDeEventosBuilder WithAggregateId(string aggregateId)
        {
            _aggregateId = aggregateId;
            return this;
        }

        public BodegaDeEventosBuilder WithEventBody(string eventBody)
        {
            _eventBody = eventBody;
            return this;
        }

        public BodegaEvento Build()
        {
            return new BodegaEvento(_storedId, _storedName, _aggregateId, _eventBody);
        }
    }
}

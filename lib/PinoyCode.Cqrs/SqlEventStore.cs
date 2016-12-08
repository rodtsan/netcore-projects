using Microsoft.EntityFrameworkCore;
using PinoyCode.Data.Infrustracture;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using CqrsModels = PinoyCode.Cqrs.Models;

namespace PinoyCode.Cqrs
{
    /// <summary>
    /// This is a simple example implementation of an event store, using a SQL database
    /// to provide the storage. Tested and known to work with SQL Server.
    /// </summary>
    public class SqlEventStore : IEventStore
    {
        private readonly IDbContext _context;
        public SqlEventStore(IDbContext context)
        {
            this._context = context;
        }

        public IEnumerable LoadEventsFor<TAggregate>(Guid id)
        {
            yield return  this.Events.Where(p => p.AggregateId == id)
                .OrderBy(o => o.SequenceNumber)
                .ForEachAsync(evt =>
                {
                    DeserializeEvent(evt.Type, evt.Body);
                });
        }

        private object DeserializeEvent(string typeName, string data)
        {
            var ser = new XmlSerializer(Type.GetType(typeName));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
            ms.Seek(0, SeekOrigin.Begin);
            return ser.Deserialize(ms);
        }

        public void SaveEventsFor<TAggregate>(Guid? aggregateId, int eventsLoaded, ArrayList newEvents)
        {
            var aggregate = new CqrsModels.Aggregate
            {
                Id = aggregateId.Value,
                AggregateType = typeof(TAggregate).AssemblyQualifiedName,
                CommitDateTime = DateTime.UtcNow
            };
            this.Aggregates.Add(aggregate);

            
            for(int i = 0; i < newEvents.Count; i++)
            {
                var e = newEvents[i];
                eventsLoaded = eventsLoaded + i;
                this.Events.Add(new CqrsModels.Event
                {
                    AggregateId = aggregateId.Value,
                    SequenceNumber = eventsLoaded,
                    Type = e.GetType().AssemblyQualifiedName,
                    Body = SerializeEvent(e),
                    CommitDateTime = aggregate.CommitDateTime
                });
            }

            this._context.Commit();
        }

        private string SerializeEvent(object obj)
        {
            var ser = new XmlSerializer(obj.GetType());
            var ms = new MemoryStream();
            ser.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            return new StreamReader(ms).ReadToEnd();
        }

        public DbSet<CqrsModels.Aggregate> Aggregates
        {
            get
            {
                return _context.Table<CqrsModels.Aggregate>();
            }
        }

        public DbSet<CqrsModels.Event> Events
        {
            get
            {
                return _context.Table<CqrsModels.Event>();
            }
        }
    }
}

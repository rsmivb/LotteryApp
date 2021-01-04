using Lottery.Models;
using MongoDB.Driver;

namespace Lottery.Repository
{
    public class MongoContext : MongoClient
    {
        public MongoContext(Database dbData) : base(dbData.Url)
        {
            Database = GetDatabase(dbData.Name);
        }

        public virtual IMongoDatabase Database { get; }

        public virtual IMongoCollection<DuplaSena> DuplaSenaRepository { get => Database.GetCollection<DuplaSena>(nameof(DuplaSena)); }
        public virtual IMongoCollection<Federal> FederalRepository { get => Database.GetCollection<Federal>(nameof(Federal)); }
        public virtual IMongoCollection<Loteca> LotecaRepository { get => Database.GetCollection<Loteca>(nameof(Loteca)); }
        public virtual IMongoCollection<LotoFacil> LotoFacilRepository { get => Database.GetCollection<LotoFacil>(nameof(LotoFacil)); }
        public virtual IMongoCollection<LotoGol> LotoGolRepository { get => Database.GetCollection<LotoGol>(nameof(LotoGol)); }
        public virtual IMongoCollection<LotoMania> LotoManiaRepository { get => Database.GetCollection<LotoMania>(nameof(LotoMania)); }
        public virtual IMongoCollection<MegaSena> MegaSenaRepository { get => Database.GetCollection<MegaSena>(nameof(MegaSena)); }
        public virtual IMongoCollection<Quina> QuinaRepository { get => Database.GetCollection<Quina>(nameof(Quina)); }
        public virtual IMongoCollection<TimeMania> TimeManiaRepository { get => Database.GetCollection<TimeMania>(nameof(TimeMania)); }
    }
}

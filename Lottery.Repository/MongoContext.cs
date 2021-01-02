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

        public virtual IMongoCollection<DuplaSena> DuplaSenaRepository { get => Database.GetCollection<DuplaSena>("DuplaSena"); }
        public virtual IMongoCollection<Federal> FederalRepository { get => Database.GetCollection<Federal>("Federal"); }
        public virtual IMongoCollection<Loteca> LotecaRepository { get => Database.GetCollection<Loteca>("Loteca"); }
        public virtual IMongoCollection<LotoFacil> LotoFacilRepository { get => Database.GetCollection<LotoFacil>("LotoFacil"); }
        public virtual IMongoCollection<LotoGol> LotoGolRepository { get => Database.GetCollection<LotoGol>("LotoGol"); }
        public virtual IMongoCollection<LotoMania> LotoManiaRepository { get => Database.GetCollection<LotoMania>("LotoMania"); }
        public virtual IMongoCollection<MegaSena> MegaSenaRepository { get => Database.GetCollection<MegaSena>("MegaSena"); }
        public virtual IMongoCollection<Quina> QuinaRepository { get => Database.GetCollection<Quina>("Quina"); }
        public virtual IMongoCollection<TimeMania> TimeManiaRepository { get => Database.GetCollection<TimeMania>("TimeMania"); }
    }
}

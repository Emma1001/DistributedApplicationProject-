using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly FootBallTransferDbContext dbContext;
        private BaseRepository<Team> teamRepository;
        private BaseRepository<Player> playerRepository;
        private BaseRepository<Transfer> transferRepository;
        private bool disposed = false;

        public UnitOfWork()
        {
            this.dbContext = new FootBallTransferDbContext();
        }

        public BaseRepository<Team> TeamRepository
        {
            get
            {
                if (this.teamRepository == null)
                {
                    this.teamRepository = new BaseRepository<Team>(dbContext);
                }

                return teamRepository;
            }
        }
        public BaseRepository<Player> PlayerRepository
        {
            get
            {
                if (this.playerRepository == null)
                {
                    this.playerRepository = new BaseRepository<Player>(dbContext);
                }

                return playerRepository;
            }
        }
        public BaseRepository<Transfer> TransferRepository
        {
            get
            {
                if (this.transferRepository == null)
                {
                    this.transferRepository = new BaseRepository<Transfer>(dbContext);
                }

                return transferRepository;
            }
        }

        public bool Save()
        {
            try
            {
                dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }

                disposed = true;
            }
        }
    }
}

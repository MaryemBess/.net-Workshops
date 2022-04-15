using System;
using System.Collections.Generic;
using System.Text;
//Libérer les ressources non gérés par G.C garbage collector
namespace PS.Data
{
    public class Disposable : IDisposable
    {
        private bool disposed;

        private void Dispose(bool disposing)
        {
             
           
                if (disposing && !disposed)
                {
                    DisposeCore();
                

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposed = true;
            }
        }

        protected virtual void DisposeCore()
        {

        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        ~Disposable()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

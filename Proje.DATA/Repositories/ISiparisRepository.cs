using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Repositories
{
    public interface ISiparisRepository : IBaseRepository<Siparis>
    {
        Siparis GetSiparisIncludeSiparisMenuler();
        List<Siparis> GetUsersSiparisListIncludeSiparisMenuler(string id);
        Siparis GetSiparisIncludeExtraMalzemelerSiparisler();
        List<Siparis> GetSiparisListIncludeExtraMalzemelerSiparisler();

        List<Siparis> GetSiparisListPiecesGreaterThan(int pieces);
        List<Siparis> GetSiparisListPiecesSmallerThan(int pieces);
    }
}

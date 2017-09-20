using mode.ShiJuan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IShiTi
    {
        bool RegisterUser(MyUserEntity myUserEntity);
        MyUserEntity Login(MyUserEntity myUserEntity);
        List<ShiJuanEntity> GetShiJuanList();
        List<ShiTiEntity> GetShiTiByShiJuanId(int shiJuanId);
        ShiTiNumEntity GetShiTiNum(int shiJuanId);
        ShiTiEntity GetNextShiTiByShiJuanIdAndCurrentIdOld(int shiJuanId,long currentShiTiId,int daTiType);
        ShiTiEntity GetPreShiTiByShiJuanIdAndCurrentIdOld(int shiJuanId, long currentShiTiId, int daTiType);
        ShiTiEntity GetGoToShiTiByShiJuanIdAndCurrentIdOld(int shiJuanId, long currentShiTiId);
        ShiTiEntity GetNextShiTiByShiJuanIdAndCurrentId(int shiJuanId, long currentShiTiId,int userId);
        List<ShiTiEntity> GetShiTiByCondition(int shiJuanId,string tiXing);
        ShiTiEntity GetNextShiTiByByCondition(int shiJuanId,string tiXing, long currentShiTiId);
        bool SaveUserDaAn(UserDaAnEntity userDaAnEntity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManager.Application.Utils
{
    public static class Settings
    {
        //Com certeza tenho conhecimento que nem de longe esta é a melhor forma de
        //salvar uma Secret de um JWT, porém fiz assim para facilitar neste projeto.
        //Este código não deve ser levado para produção.
        public static string Secret = "61990e3133e444e6b11eeeed51c44f6a";
    }
}

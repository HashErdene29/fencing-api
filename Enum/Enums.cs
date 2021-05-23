using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi.Enum
{
    public enum IsEnable
    {
        Идэвхгүй = 0,
        Идэвхтэй = 1
    }
    public enum Type
    {
        Програмист = 4,
        Нэвтрүүлэгч = 1,
        Борлуулагч = 2,
        PO = 3
    }
    public enum Status
    {
        Захиалга_үүссэн = 1,
        Хүлээгдэж_байгаа = 2,
        Төлбөр_баталгаажсан = 3,
        Захиалга_амжилттай = 4
    }
    public enum Role
    {
        Захиалагч = 1,
        Үйлчилгээ_үзүүлэгч = 2
    }
}
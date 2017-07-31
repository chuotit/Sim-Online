using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimOnline.Data.Infrastructure
{
    // Là một giao tiếp để khởi tạo các đối tượng Entity
    // Không khởi tạo trực tiếp mà khởi tạo thông qua factory này
    // Chúng ta áp dụng mẫu factory ở trong design patterm

    // Kế thừa từ IDisposable
    public interface IDbFactory : IDisposable
    {
        // Dùng phương thức init để init DbContext.
        SimOnlineDbContext Init();
    }
}

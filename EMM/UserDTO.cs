using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMM
{
    public class UserDTO
    {
        private String id;
        private String role;

        public UserDTO() { }
        public UserDTO(String id, String role)
        {
            this.id = id;
            this.role = role;
        }
        public String getRole()
        {
            return this.role;
        }
        public String getId()
        {
            return this.id;
        }
    }
}

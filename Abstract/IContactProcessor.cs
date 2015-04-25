using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoqibaoStore.Models;

namespace AoqibaoStore.Abstract
{
  public interface IContactProcessor
    {
      void ProcessContact(Contact contact);
    }
}

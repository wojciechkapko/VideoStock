using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStock.Domain.Enums
{
    public enum ContentType
    {
        [Description("Image")]
        Image,
        [Description("Video")]
        Video
    }
}

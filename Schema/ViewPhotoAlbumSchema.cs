using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
   public class ViewPhotoAlbumSchema
    {
        private int photosubalbumid;
        private string actionType;
        private int photoalbumid;
        private string name;
        private string albumname;
        private string fileName;


        public int PhotoSubAlbumID
        {
            get { return photosubalbumid; }

            set { photosubalbumid = value; }
        }

        public string ActionType
        {
            get { return actionType; }

            set { actionType = value; }
        }


        public int Photoalbumid
        {
            get { return photoalbumid; }

            set { photoalbumid = value; }
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public string Albumname
        {
            get { return albumname; }

            set { albumname = value; }
        }

        public string FileName
        {
            get { return fileName; }

            set { fileName = value; }
        }
    }
}

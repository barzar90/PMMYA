using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class AlbumSchema
    {
        private string type;
        private string albumName;
        private string albumID;
        private int pressNewsAlbumID;
        private string actiontype;
        private bool chkStatus;
        private string videoName;
        private string videoNameLL;
        private string videoNameUL;
        private string videoPath;
        private string description;
        private string descriptionLL;
        private string descriptionUL;
        private string createdBy;
        private string ipAddress;
        private string imagePath;
        private string flag;
        private int videoID;
        private string name;
        private int photoSubAlbumID;
        private int photoID;
        private string filename;
        private string photoType;
        private int photoAlbumID;
        private int typeId;

        public string AlbumName
        {
            get { return albumName; }

            set { albumName = value; }
        }

        public string AlbumID
        {
            get { return albumID; }

            set { albumID = value; }
        }

        public int PressNewsAlbumID
        {
            get { return pressNewsAlbumID; }

            set { pressNewsAlbumID = value; }
        }

        public string Type
        {
            get { return type; }

            set { type = value; }
        }

        public string Actiontype
        {
            get { return actiontype; }

            set { actiontype = value; }
        }

        public bool ChkStatus
        {
            get { return chkStatus; }

            set { chkStatus = value; }
        }

        public string VideoName
        {
            get { return videoName; }

            set { videoName = value; }
        }

        public string VideoNameLL
        {
            get { return videoNameLL; }

            set { videoNameLL = value; }
        }

        public string VideoNameUL
        {
            get { return videoNameUL; }

            set { videoNameUL = value; }
        }


        public string VideoPath
        {
            get { return videoPath; }

            set { videoPath = value; }
        }

        public string Description
        {
            get { return description; }

            set { description = value; }
        }
        public string DescriptionLL
        {
            get { return descriptionLL; }

            set { descriptionLL = value; }
        }
        public string DescriptionUL
        {
            get { return descriptionUL; }

            set { descriptionUL = value; }
        }
        public string CreatedBy
        {
            get { return createdBy; }

            set { createdBy = value; }
        }

        public string IPAddress
        {
            get { return ipAddress; }

            set { ipAddress = value; }
        }

        public string ImagePath
        {
            get { return imagePath; }

            set { imagePath = value; }
        }

        public string Flag
        {
            get { return flag; }

            set { flag = value; }
        }

        public int VideoID
        {
            get { return videoID; }

            set { videoID = value; }
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public int PhotoSubAlbumID
        {
            get { return photoSubAlbumID; }

            set { photoSubAlbumID = value; }
        }

        public int PhotoID
        {
            get { return photoID; }

            set { photoID = value; }
        }

        public string Filename
        {
            get { return filename; }

            set { filename = value; }
        }

        public string PhotoType
        {
            get { return photoType; }

            set { photoType = value; }
        }

        public int PhotoAlbumID
        {
            get { return photoAlbumID; }

            set { photoAlbumID = value; }
        }

        public int TypeId
        {
            get { return typeId; }

            set { typeId = value; }
        }
    }
}

namespace PhotoAlbum.api
{
	public class PhotoViewModel
    {
        public int PhotoId { get; set;
        }
        public string AlbumTitle { get; set; }

        public string PhotoTitle { get; set; }

        public string URL { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}

/{user_id}/Albums
/{user_id}/Photos
/{user_id}/Photos?photoId={photo_id}
/{user_id}/Photos?albumId={album_id}

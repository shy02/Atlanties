using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Profile_Setting : MonoBehaviour
{ 
	Image img;
    void Start(){

        PickImage(512);
    }
private void PickImage( int maxSize )
{
	NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
	{
		Debug.Log( "Image path: " + path );
		if( path != null )
		{
			// Create Texture from selected image
			Texture2D texture = NativeGallery.LoadImageAtPath( path, maxSize );
			if( texture == null )
			{
				Debug.Log( "Couldn't load texture from " + path );
				return;
			}
		}
	} );

	Debug.Log( "Permission result: " + permission );
}

}

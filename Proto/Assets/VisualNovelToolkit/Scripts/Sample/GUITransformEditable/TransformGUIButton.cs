//_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/.
// 			VisualNovelToolkit		     /_/_/_/_/_/_/_/_/_/.
// Copyright ©2013 - Sol-tribe.	/_/_/_/_/_/_/_/_/_/.
//_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/.
using UnityEngine;
using System.Collections;

[ ExecuteInEditMode ]
public class TransformGUIButton : MonoBehaviour {
	public string label;
	public bool fitToScreenWidth;
	public Texture2D texture;
	public GameObject onClick;
	public string sendMessage;
	public string paramString = null;
	public bool isEnabled = true;

	private Rect m_Rect;
	private Transform thisTransform;
	
	protected float originalWidth = 854.0f;
	protected float originalHeight = 480.0f;
	protected Vector3 s = Vector3.zero;	
	protected Matrix4x4 svMat;
	
	// Use this for initialization
	void Start () {
		thisTransform = transform;
	}
	
	void OnGUI(){			
		GUI.enabled = isEnabled;

		Vector3 pos = thisTransform.position;
		Vector3 scale = thisTransform.localScale;
		if( fitToScreenWidth ){			
			thisTransform.localScale = new Vector3( Screen.width , scale.y , 1f );
			scale.x = Screen.width;			
		}
		pos.x += Screen.width /2f;
		pos.y += - Screen.height /2f;
		m_Rect = new Rect( pos.x , - pos.y , scale.x , scale.y );
		bool isClick = false;
		if( texture == null ){
			if( GUI.Button( m_Rect ,  label  ) ){
				isClick = true;
			}			
		}
		else{
			if( GUI.Button( m_Rect , texture ,  label  ) ){
				isClick = true;
			}							
		}	
		
		GUI.enabled = true;				

		if( Application.isPlaying && isClick ){
			if( onClick != null ){
				if( string.IsNullOrEmpty( paramString ) ){
					onClick.SendMessage( sendMessage , SendMessageOptions.DontRequireReceiver );
				}
				else{
					onClick.SendMessage( sendMessage , paramString , SendMessageOptions.DontRequireReceiver );					
				}
			}
		}	
	}
	
}

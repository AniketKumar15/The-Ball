using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RollerBall : MonoBehaviour {

	public GameObject ViewCamera = null;
	public AudioClip JumpSound = null;
	public AudioClip HitSound = null;
	public AudioClip CoinSound = null;
	public int speed = 20000;
	private Rigidbody mRigidBody = null;
	private AudioSource mAudioSource = null;
	public bool mFloorTouched = false;
	public GameManager gameManager;
	void Start () {
		mRigidBody = GetComponent<Rigidbody> ();
		mAudioSource = GetComponent<AudioSource> ();
		
	}

	void FixedUpdate () {
		if (mRigidBody != null) {
			if (Input.GetButton ("Horizontal")) {
				mRigidBody.AddTorque(Vector3.back * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
			}
			if (Input.GetButton ("Vertical")) {
				mRigidBody.AddTorque(Vector3.right * Input.GetAxis("Vertical") * speed * Time.deltaTime);
			}
			if (Input.GetButtonDown("Jump") && mFloorTouched == true) 
			{
				if(mAudioSource != null && JumpSound != null){
					mAudioSource.PlayOneShot(JumpSound);
				}
				mRigidBody.AddForce(Vector3.up*200);
			}
		}
		if (ViewCamera != null) {
			Vector3 direction = (Vector3.up*11+Vector3.back)*2;
			RaycastHit hit;
			Debug.DrawLine(transform.position,transform.position+direction,Color.red);
			if(Physics.Linecast(transform.position,transform.position+direction,out hit)){
				ViewCamera.transform.position = hit.point;
			}else{
				ViewCamera.transform.position = transform.position+direction;
			}
			ViewCamera.transform.LookAt(transform.position);
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag.Equals ("Floor")) {
			mFloorTouched = true;
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.y > .5f) {
				mAudioSource.PlayOneShot (HitSound, coll.relativeVelocity.magnitude);
			}
		} else {
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.magnitude > 2f) {
				mAudioSource.PlayOneShot (HitSound, coll.relativeVelocity.magnitude);
			}
		}
		if (coll.gameObject.tag == "Wall")
		{
			gameManager.losser();
			Time.timeScale = 0;
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void OnCollisionExit(Collision coll){
		if (coll.gameObject.tag.Equals ("Floor")) {
			mFloorTouched = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Coin")) 
		{
			gameManager.keyCount++;
			gameManager.tempKey--;
			if(mAudioSource != null && CoinSound != null)
			{
				mAudioSource.PlayOneShot(CoinSound);
			}
			Destroy(other.gameObject);
		}

		//if (other.gameObject.tag.Equals("Win"))
  //      {
  //          if (gameManager.keyCount == gameManager.needOtOpen)
  //          {
		//		SceneManager.LoadScene(0);
		//	}
  //      }
	}

	//public void HorRight()
 //   {
	//	realSpeed = mobileSpeed;
	//	mRigidBody.AddTorque(Vector3.back * 1 * realSpeed);
	//	Debug.Log("Move");
	//}
	//public void Horleft()
	//{
	//	realSpeed = mobileSpeed;
	//	mRigidBody.AddTorque(Vector3.back * -1 * realSpeed);
	//}
	//public void verUp()
	//{
	//	realSpeed = mobileSpeed;
	//	mRigidBody.AddTorque(Vector3.right * 1 * realSpeed);
	//}
	//public void VerDown()
	//{
	//	realSpeed = mobileSpeed;
	//	mRigidBody.AddTorque(Vector3.right * -1 * realSpeed);
	//}
	//public void PointerUp()
 //   {
	//	realSpeed = 0;
 //   }
}

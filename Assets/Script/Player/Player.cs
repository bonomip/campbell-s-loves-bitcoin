using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	static private GameObject player;

	static private Rigidbody2D rigidBody2D;
	static private BoxCollider2D boxCollider2D;
	static private SpriteRenderer spriteRender;

	static private Transform c_groundCheck;
	static private Transform l_groundCheck;
	static private Transform r_groundCheck;

	static private Transform checkPoint;

	static private LayerMask selectGround;

	static private PlayerReloadCP PLreload;
	static private PlayerMovement PLmovement;
	static private PlayerSpriteAnimator PLanimator;

	// Use this for initialization
	void Start () {
		player = this.gameObject;

		rigidBody2D = GetComponent<Rigidbody2D> ();
		boxCollider2D = GetComponent<BoxCollider2D> ();
		spriteRender = GetComponent<SpriteRenderer> ();

		c_groundCheck = GameObject.Find ("c_groundCheck").transform;
		l_groundCheck = GameObject.Find ("l_groundCheck").transform;
		r_groundCheck = GameObject.Find ("r_groundCheck").transform;
	
		checkPoint = GameObject.Find ("checkPoint").transform;

		PLreload = GetComponent<PlayerReloadCP> ();
		PLmovement = GetComponent<PlayerMovement> ();
		PLanimator = GetComponent<PlayerSpriteAnimator> ();

		selectGround = 1 << 8;
	}
		

	static public GameObject self {
		get { return player; }
	}
		
	static public Rigidbody2D rb {
		get { return rigidBody2D; }
	}

	static public BoxCollider2D bc {
		get { return boxCollider2D; }
	}

	static public SpriteRenderer sr {
		get { return spriteRender; }
	}

	static public PlayerMovement pl_mov {
		get {  return PLmovement; }
	}

	static public PlayerReloadCP pl_reload {
		get { return  PLreload; }
	}

	static public PlayerSpriteAnimator pl_anim {
		get { return PLanimator; }
	}
		
	static public Transform c_check {
		get { return c_groundCheck; }
	}

	static public Transform l_check {
		get { return l_groundCheck; }
	}

	static public Transform r_check {
		get { return r_groundCheck; }
	}
		
	static public Transform cp {
		get {  return checkPoint; }
		set { checkPoint = value;  }
	}
		
	static public LayerMask ground {
		get { return selectGround; }
	}
}
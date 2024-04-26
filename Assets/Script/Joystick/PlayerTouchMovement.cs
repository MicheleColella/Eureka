using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTouchMovement : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public InventoryManager InventoryManager;
    public Enemyradar enemyradar;
    public Enemyradar enemyradar2;
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private AnimatorController _animatorController;

    [SerializeField] public float _movespeed;
    [SerializeField] private float _rotateSpeed;

    public GameObject Target1Weapon;
    public GameObject Target2Weapon;

    private Rigidbody _rigidbody;

    private Vector3 _moveVector;

    [Header("Idle Maker")]
    public float xrand;
    public float yrand;
    public float zrand;
    public float xrand2;
    public float yrand2;
    public float zrand2;
    public float xoffset;
    public float yoffset;
    public float zoffset;
    public int interpolationFramesCount = 45;
    int elapsedFrames = 0;
    int elapsedFrames2 = 0;
    Vector3 oldpos;
    Vector3 StartPos;
    Vector3 oldpos2;
    Vector3 StartPos2;
    public bool MakeIdle;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        xrand = Random.Range(0, xoffset);
        yrand = Random.Range(0, yoffset);
        zrand = Random.Range(0, zoffset);
        xrand2 = Random.Range(0, xoffset);
        yrand2 = Random.Range(0, yoffset);
        zrand2 = Random.Range(0, zoffset);
        StartPos = Target1Weapon.transform.localPosition;
        oldpos = Target1Weapon.transform.localPosition;
        StartPos2 = Target2Weapon.transform.localPosition;
        oldpos2 = Target2Weapon.transform.localPosition;
    }
    private void FixedUpdate()
    {
        if (!playerHealth.Dieing)
        {
            Move();
            GunMove();
        }
    }

    private void GunMove()
    {
        if (InventoryManager.Weapon1Equip)
        {
            InventoryItem itemInSlot = InventoryManager.EquipSlots[2].GetComponentInChildren<InventoryItem>();
            enemyradar.GetComponent<SphereCollider>().radius = itemInSlot.item.Shootrange;
        }

        if (InventoryManager.Weapon2Equip)
        {
            InventoryItem itemInSlot = InventoryManager.EquipSlots[3].GetComponentInChildren<InventoryItem>();
            enemyradar2.GetComponent<SphereCollider>().radius = itemInSlot.item.Shootrange;
        }

        if (enemyradar.enemyContact && InventoryManager.Weapon1Equip)
        {
            //Debug.Log("Contact");
            InventoryItem itemInSlot = InventoryManager.EquipSlots[2].GetComponentInChildren<InventoryItem>();
            enemyradar.GetComponent<SphereCollider>().radius = itemInSlot.item.Shootrange;
            Quaternion OriginalRot = Target1Weapon.transform.rotation;
            Target1Weapon.transform.LookAt(enemyradar.closestEnemy);
            Quaternion NewRot = Target1Weapon.transform.rotation;
            Target1Weapon.transform.rotation = OriginalRot;
            Target1Weapon.transform.rotation = Quaternion.Lerp(Target1Weapon.transform.rotation, NewRot, Time.deltaTime * itemInSlot.item.Precision);
        }
        else if(!enemyradar.enemyContact)
        {
            //Debug.Log("Not");
            Quaternion target = Quaternion.Euler(0, 0, 0);
            Target1Weapon.transform.localRotation = Quaternion.Slerp(Target1Weapon.transform.localRotation, target, Time.deltaTime * 5.0f);
        }

        if (MakeIdle)
        {
            IdleMove();
            IdleMove2();
        }
        


        if (enemyradar2.enemyContact && InventoryManager.Weapon2Equip)
        {
            InventoryItem itemInSlot = InventoryManager.EquipSlots[3].GetComponentInChildren<InventoryItem>();
            enemyradar2.GetComponent<SphereCollider>().radius = itemInSlot.item.Shootrange;
            Quaternion OriginalRot2 = Target2Weapon.transform.rotation;
            Target2Weapon.transform.LookAt(enemyradar2.closestEnemy);
            Quaternion NewRot2 = Target2Weapon.transform.rotation;
            Target2Weapon.transform.rotation = OriginalRot2;
            Target2Weapon.transform.rotation = Quaternion.Lerp(Target2Weapon.transform.rotation, NewRot2, Time.deltaTime * itemInSlot.item.Precision);
        }
        else if(!enemyradar2.enemyContact)
        {
            Quaternion target2 = Quaternion.Euler(0, 0, 0);
            Target2Weapon.transform.localRotation = Quaternion.Slerp(Target2Weapon.transform.localRotation, target2, Time.deltaTime * 5.0f);
        }
        
    }

    private void IdleMove()
    {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        
        Vector3 distance = Target1Weapon.transform.localPosition - new Vector3(StartPos.x + xrand, StartPos.y + yrand, StartPos.z + zrand);
        if(distance != Vector3.zero)
        {
            Target1Weapon.transform.localPosition = Vector3.Lerp(oldpos, new Vector3(StartPos.x + xrand, StartPos.y + yrand, StartPos.z + zrand), interpolationRatio);
            elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);
            //Debug.Log(distance);
        }
        else
        {
            oldpos = Target1Weapon.transform.localPosition;
            xrand = Random.Range(0f, xoffset);
            yrand = Random.Range(0f, yoffset);
            zrand = Random.Range(0f, zoffset);
        }
        //Debug.DrawLine(oldpos, new Vector3(Target1Weapon.transform.localPosition.x, Target1Weapon.transform.localPosition.y, Target1Weapon.transform.localPosition.z), Color.green);
    }

    private void IdleMove2()
    {
        float interpolationRatio = (float)elapsedFrames2 / interpolationFramesCount;

        Vector3 distance = Target2Weapon.transform.localPosition - new Vector3(StartPos2.x + xrand2, StartPos2.y + yrand2, StartPos2.z + zrand2);
        if (distance != Vector3.zero)
        {
            Target2Weapon.transform.localPosition = Vector3.Lerp(oldpos2, new Vector3(StartPos2.x + xrand2, StartPos2.y + yrand2, StartPos2.z + zrand2), interpolationRatio);
            elapsedFrames2 = (elapsedFrames2 + 1) % (interpolationFramesCount + 1);
            //Debug.Log(distance);
        }
        else
        {
            oldpos2 = Target2Weapon.transform.localPosition;
            xrand2 = Random.Range(0f, xoffset);
            yrand2 = Random.Range(0f, yoffset);
            zrand2 = Random.Range(0f, zoffset);
        }
        //Debug.DrawLine(oldpos2, new Vector3(Target2Weapon.transform.localPosition.x, Target2Weapon.transform.localPosition.y, Target2Weapon.transform.localPosition.z), Color.green);
    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _movespeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * _movespeed * Time.deltaTime;

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);

            transform.rotation = Quaternion.LookRotation(direction);

            _animatorController.PlayRun();
        }
        else if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            _animatorController.PlayIdle();
        }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideStepDoubleInput : MonoBehaviour
{
    float stepCountL;
    float stepCountR;
    float stepTimer;
    float stepSign;
    bool sideStepL;
    bool sideStepR;
    bool isSideStep;
    float sideStepTime;
    float sideStepTimer;
    Rigidbody rb;
    float sideStepSpeed;
    private void SideStep()
    {
        if (stepCountL > 0 || stepCountR > 0)
        {
            stepTimer += Time.deltaTime;
        }
        if (stepCountL > 1 && stepTimer < 0.3f)
        {
            stepSign = -1;
            stepCountL = 0;
        }
        else if (stepCountR > 1 && stepTimer < 0.5f)
        {
            stepSign = 1;
            stepCountR = 0;
        }
        bool leftInput = Input.GetKeyDown(KeyCode.A);
        bool rightInput = Input.GetKeyDown(KeyCode.D);
        if (leftInput)
        {
            stepCountL++;
            stepTimer += Time.deltaTime;
        }
        if (rightInput)
        {
            stepCountR++;
            stepTimer += Time.deltaTime;
        }
        if (stepCountL >= 2 && stepTimer < 0.5f)
        {
            sideStepL = true;
            stepCountL = 0;
            stepTimer = 0;
        }
        else if (stepCountR >= 2 && stepTimer < 0.5f)
        {
            sideStepR = true;
            stepCountR = 0;
            stepTimer = 0;
        }
        else if (stepTimer >= 0.6f)
        {
            stepTimer = 0;
        }
        if (sideStepL)
        {
            stepSign = -1;
            isSideStep = true;
        }
        if (sideStepR)
        {
            stepSign = 1;
            isSideStep = true;
        }
        if (isSideStep)
        {
            sideStepTimer += Time.deltaTime;
            Debug.Log(sideStepTimer);

            if (sideStepTimer > sideStepTime)
            {
                sideStepTimer = 0;
                isSideStep = false;
                return;
            }

            rb.AddForce(transform.right * sideStepSpeed * stepSign, ForceMode.VelocityChange);
        }
    }
}

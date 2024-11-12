/*
Flying mod
*/

private bool MOD_isFlying = false; // EDIT: add this to the class!!!

private void Move()
{
    if (Input.GetKeyDown(KeyCode.G)) { this.MOD_isFlying = !this.MOD_isFlying; } // EDIT: toggle flying with 'g'                                                       //

    float num;
    if (this.IsCrouching)
    {
        num = this.CrouchSpeed;
    }
    else
    {
        num = (this.MainPlayer.GetButton("Sprint") ? this.SprintSpeed : this.MoveSpeed);
    }
    float axisRaw = this.MainPlayer.GetAxisRaw("MoveH");
    float axisRaw2 = this.MainPlayer.GetAxisRaw("MoveV");
    Vector2 lhs = new Vector2(axisRaw, axisRaw2);
    if (lhs == Vector2.zero || !this.allowPlayerInput)
    {
        num = 0f;
    }
    if (this.MOD_isFlying)                              // EDIT: handle vertical velocity
    {                                                   //
        this.MoveSpeed = 10f;                           //
        this.SprintSpeed = 20f;                         //
        if (Input.GetKey(KeyCode.Space))                //
        {                                               //
            this._verticalVelocity = this.MoveSpeed;    //
        }                                               //
        else if (Input.GetKey(KeyCode.R))               //
        {                                               //
            this._verticalVelocity = -this.MoveSpeed;   //
        }                                               //
        else                                            //
        {                                               //
            this._verticalVelocity = 0f;                //
        }                                               //
    }                                                   //
    else                                                //
    {                                                   //
        this.MoveSpeed = 5f;                            //
        this.SprintSpeed = 10f;                         //
    }                                                   //
    float magnitude = new Vector3(this._controller.velocity.x, 0f, this._controller.velocity.z).magnitude;
    float num2 = 0.1f;
    float magnitude2 = lhs.magnitude;
    if (magnitude < num - num2 || magnitude > num + num2)
    {
        this._speed = Mathf.Lerp(magnitude, num * magnitude2, Time.deltaTime * this.SpeedChangeRate);
        this._speed = Mathf.Round(this._speed * 1000f) / 1000f;
    }
    else
    {
        this._speed = num;
    }
    this._speed = Mathf.Clamp(this._speed, 0f, this.SprintSpeed);
    Vector3 vector = new Vector3(axisRaw, 0f, axisRaw2).normalized;
    if (lhs != Vector2.zero)
    {
        vector = base.transform.right * axisRaw + base.transform.forward * axisRaw2;
        if (!this.Grounded)
        {
            float num3 = this.MainPlayer.GetButton("Sprint") ? 0.96f : 0.94f;
            this._speed *= num3;
        }
    }
    if (!this.isTeleporting && !this.isBeingPushed)
    {
        this._controller.Move(vector.normalized * (this._speed * Time.deltaTime) + new Vector3(0f, this._verticalVelocity, 0f) * Time.deltaTime);
        return;
    }
    this._controller.Move(this.pushDirection.normalized * (3f * Time.deltaTime) + new Vector3(0f, this._verticalVelocity, 0f) * Time.deltaTime);
}
Public Float dashCooldown;
Public GameObject dashParticle;
void start()
{
dashCooldown -=Time.deltaTime;
}

else if (Input.GetKey("e"))&& dashCooldown<=0>
{
  Dash();
}
public void Dash()
{
 GameObject dashObject;
 
 // dashObject= Instantiate(dashParticle,transform.position,transform.rotation);
   if (spriteRender.flipX==true)
   {
   rb2D.AddForce(-Vector2.left*dashForce,ForceMode2D.Impulse);
   }
   else
   {
   rb2D.AddForce(-Vector2.right*dashForce,ForceMode2D.Impulse);
   }
   
   dashCooldown = 2;
   
   Destroy(dashObject,1)

}

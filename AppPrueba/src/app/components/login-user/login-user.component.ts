import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserCredentials } from 'src/app/models/user-credentials';
import { UserAccountService } from 'src/app/services/user-account.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.sass']
})
export class LoginUserComponent{
  
  loginForm: FormGroup;
  errorCredentials: boolean = false;

  constructor(private formBuilder: FormBuilder, private userService: UserAccountService, private router: Router) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });

    this.loginForm.valueChanges.subscribe(data => this.errorCredentials = false);
  }

  onSubmit() {
    if(this.loginForm.valid){
      this.userService.loginUserAccount(
        new UserCredentials(this.loginForm.get("email")?.value, this.loginForm.get("password")?.value))
        .subscribe(
          response => {
            if (response.id !== undefined) {
              this.router.navigate(['/user', response.id]);
            }
          },
          error => {
            if (error.status === 404) {
              this.errorCredentials = true;
            }
          }
        );
    }
  }
}

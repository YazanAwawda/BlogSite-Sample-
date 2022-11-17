import { Component, Injectable, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { User } from '../model/user';
import { UserServiceService } from '../services/user-service.service';
import { AlertifyService } from '../services/alertify.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { EncryptionService } from '../services/encryption.service';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
@Injectable()
export class RegistrationComponent implements OnInit {

  registrationForm: UntypedFormGroup;
  user: User;
  userSubmitted: boolean;
  userNameTaken: boolean;

  constructor(private fb: UntypedFormBuilder,
    private userService: UserServiceService,
    private alertify: AlertifyService,
    private encryptionService: EncryptionService,
    private http: HttpClient,
    private router: Router) { }

  ngOnInit() {
    // this.registrationForm = new FormGroup(
    //   {
    //     userName : new FormControl(null, Validators.required),
    //     email: new FormControl(null, [Validators.required, Validators.email]),
    //     password : new FormControl(null, [Validators.required, Validators.minLength(8)]),
    //     ConfirmPassword : new FormControl(null,Validators.required)
    //   }, this.passwordMatchingValidator
    // );
    this.createRegistrationform();
  }

  createRegistrationform() {
    this.registrationForm = this.fb.group(
      {
        userName: [null, Validators.required],
        email: [null, [Validators.required, Validators.email]],
        password: [null, [Validators.required, Validators.minLength(8)]],
        ConfirmPassword: [null, Validators.required]
      }, { validators: this.passwordMatchingValidator }
    );
  }

  passwordMatchingValidator(fg: UntypedFormGroup): Validators {
    return fg.get('password').value === fg.get('ConfirmPassword').value ? null :
      { notmatched: true }
  }

  get userName() {
    return this.registrationForm.get('userName') as UntypedFormControl;
  }

  get email() {
    return this.registrationForm.get('email') as UntypedFormControl;
  }

  get password() {
    return this.registrationForm.get('password') as UntypedFormControl;
  }

  get ConfirmPassword() {
    return this.registrationForm.get('ConfirmPassword') as UntypedFormControl;
  }

  onSubmit() {
    this.userSubmitted = true;

    if (this.registrationForm.valid) {
      console.log(this.registrationForm);
      this.userService.getUserByName(this.userName.value).subscribe(
        data => {
          console.log(data);
          if (data) {
            this.userNameTaken = true;
            console.log(this.userNameTaken);
            this.alertify.error("username taken");
          } else {
            this.userNameTaken = false;
            console.log(this.userNameTaken);
            if (!this.userNameTaken) {
              this.userService.addUser(this.userData()).subscribe(
                data => {
                  console.log(data);
                }
              );
              this.registrationForm.reset();
              this.userSubmitted = false;
              this.alertify.success("You have successfully registered, login with your credentials");
              this.router.navigate(['/login']);
            } else {
              this.alertify.error("username taken");
            }
          }
        }
      );
      //this.user = Object.assign(this.user, this.registrationForm.value);
      //this.userService.addUser(this.userData());
      console.log(this.userNameTaken);


    } else {
      this.alertify.error("Kindly provide the required fields");
    }

  }

  userData(): User {
    return this.user = {
      userName: this.userName.value,
      email: this.email.value,
      password: this.encryptionService.encryptPass(this.password.value)
    }
  }

}

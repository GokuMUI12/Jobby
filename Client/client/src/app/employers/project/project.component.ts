import { Component, ElementRef, OnInit, ViewChild, } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { JobService } from '../job.service';
import { Router } from '@angular/router';
import { JobCategory } from 'src/app/shared/models/job';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css'],
})

export class ProjectComponent implements OnInit {
  jobForm!: FormGroup
  jobCategories: any[] = [];
  @ViewChild('skillInput') someInput!: ElementRef;
  constructor(private fb: FormBuilder, private jobService: JobService, private router: Router) { }

  ngOnInit(): void {
    this.getCategories();

    this.jobForm = this.fb.group({
      title: [''],
      categoryId: [null, Validators.required],
      expectedDays: [null, Validators.required],
      budget: [null, Validators.required],
      description: [''],
      skills: this.fb.array([])
    })

  }
  onSubmit() {
    this.jobService.addJob(this.jobForm.value).subscribe(
      (response) => {
        console.log(response, 'Job Created Successfully')
      }
    )
  }
  addSkill(skill: string) {
    const skillsArray = this.jobForm.get('skills') as FormArray;
    skillsArray.push(new FormControl(skill));
    this.someInput.nativeElement.value = '';
  }

  removeSkill(index: number) {
    const skillsArray = this.jobForm.get('skills') as FormArray;
    skillsArray.removeAt(index);
  }

  getCategories() {
      this.jobService.getJobCategories().subscribe(categories => {
      console.log(categories);
      this.jobCategories = categories
    })
  }
}

import { TestBed } from '@angular/core/testing';
import { Component, OnInit } from '@angular/core';

import { SchoolService } from './school.service';

describe('SchoolService', () => {
  let service: SchoolService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SchoolService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});


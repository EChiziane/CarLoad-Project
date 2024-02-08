import {ComponentFixture, TestBed} from '@angular/core/testing';

import {CarLoadComponent} from './car-load.component';

describe('CarLoadComponent', () => {
    let component: CarLoadComponent;
    let fixture: ComponentFixture<CarLoadComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [CarLoadComponent]
        })
            .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(CarLoadComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

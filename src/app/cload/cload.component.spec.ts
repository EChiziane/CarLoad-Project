import {ComponentFixture, TestBed} from '@angular/core/testing';

import {CloadComponent} from './cload.component';

describe('CloadComponent', () => {
    let component: CloadComponent;
    let fixture: ComponentFixture<CloadComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [CloadComponent]
        })
            .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(CloadComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

export type FieldType = 'text' | 'date' | 'number' | 'select' | 'checkbox' | 'radio';

export interface FieldOption {
    value: string | number;
    label: string;
}

export interface ValidationRule {
    type: 'required' | 'email' | 'minLength' | 'maxLength' | 'minDate' | 'maxDate';
    params?: any;
    message?: string;
}

export interface FormFieldSchema {
    name: string;
    label: string;
    type: FieldType;
    placeholder?: string;
    options?: FieldOption[];
    validation?: ValidationRule[];
    value?: any;
}

export interface FormSchema {
    fields: FormFieldSchema[];
}

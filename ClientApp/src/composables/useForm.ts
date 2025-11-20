import { reactive, computed } from 'vue';
import useVuelidate from '@vuelidate/core';
import { required, email, minLength, maxLength, helpers } from '@vuelidate/validators';
import type { FormSchema, ValidationRule } from '../types/form';

export function useForm(schema: FormSchema) {
    const formData = reactive<Record<string, any>>({});
    const rules = computed(() => {
        const rulesObj: Record<string, any> = {};

        schema.fields.forEach(field => {
            const fieldRules: Record<string, any> = {};

            if (formData[field.name] === undefined) {
                formData[field.name] = field.value !== undefined ? field.value : (field.type === 'checkbox' ? false : '');
            }

            if (field.validation) {
                field.validation.forEach((rule: ValidationRule) => {
                    switch (rule.type) {
                        case 'required':
                            fieldRules.required = required;
                            break;
                        case 'email':
                            fieldRules.email = email;
                            break;
                        case 'minLength':
                            fieldRules.minLength = minLength(rule.params);
                            break;
                        case 'maxLength':
                            fieldRules.maxLength = maxLength(rule.params);
                            break;
                        case 'minDate':
                            fieldRules.minDate = helpers.withMessage(
                                rule.message || `Date must be after ${rule.params}`,
                                (value: string) => {
                                    if (!value) return true;
                                    return new Date(value) >= new Date(rule.params);
                                }
                            );
                            break;
                        case 'maxDate':
                            fieldRules.maxDate = helpers.withMessage(
                                rule.message || `Date must be before ${rule.params}`,
                                (value: string) => {
                                    if (!value) return true;
                                    const date = new Date(value);
                                    const max = rule.params === 'today' ? new Date() : new Date(rule.params);

                                    return date <= max;
                                }
                            );
                            break;
                    }
                });
            }
            rulesObj[field.name] = fieldRules;
        });

        return rulesObj;
    });

    const v$ = useVuelidate(rules, formData);

    const validate = async () => {
        const result = await v$.value.$validate();
        return result;
    };

    const reset = () => {
        v$.value.$reset();
        schema.fields.forEach(field => {
            formData[field.name] = field.value !== undefined ? field.value : (field.type === 'checkbox' ? false : '');
        });
    };

    return {
        formData,
        v$,
        validate,
        reset
    };
}

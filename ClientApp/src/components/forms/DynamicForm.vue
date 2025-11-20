<script setup lang="ts">
import type { FormSchema } from '../../types/form';
import { useForm } from '../../composables/useForm';
import FormField from './FormField.vue';
import BaseButton from '../ui/BaseButton.vue';
import BaseInput from '../ui/BaseInput.vue';
import BaseSelect from '../ui/BaseSelect.vue';
import BaseCheckbox from '../ui/BaseCheckbox.vue';
import BaseRadio from '../ui/BaseRadio.vue';

const props = defineProps<{
  schema: FormSchema;
  submitLabel?: string;
  isLoading?: boolean;
}>();

const emit = defineEmits<{
  (e: 'submit', data: Record<string, any>): void;
}>();

const { formData, v$, validate, reset } = useForm(props.schema);

const componentMap: Record<string, any> = {
  text: BaseInput,
  date: BaseInput,
  number: BaseInput,
  select: BaseSelect,
  checkbox: BaseCheckbox,
  radio: BaseRadio,
};



const getInputType = (type: string) => {
  if (type === 'date') return 'date';
  if (type === 'number') return 'number';
  return 'text';
};

const getDateRuleParam = (validation: any[] | undefined, ruleType: string) => {
  if (!validation) return undefined;
  const rule = validation.find(r => r.type === ruleType);
  if (!rule) return undefined;
  return rule.params === 'today' ? new Date().toISOString().split('T')[0] : rule.params;
};

const handleSubmit = async () => {
  const isValid = await validate();
  if (isValid) {
    emit('submit', { ...formData });
    reset();
  }
};
</script>

<template>
  <form @submit.prevent="handleSubmit" class="dynamic-form">
    <FormField
      v-for="field in schema.fields"
      :key="field.name"
      :label="field.label"
      :error="v$[field.name]?.$errors[0]?.$message as string"
      :id="field.name"
    >
      <component
        :is="componentMap[field.type]"
        v-model="formData[field.name]"
        :id="field.name"
        :type="getInputType(field.type)"
        :placeholder="field.placeholder"
        :options="field.options"
        :name="field.name"
        :invalid="v$[field.name]?.$error"
        :max="getDateRuleParam(field.validation, 'maxDate')"
        :min="getDateRuleParam(field.validation, 'minDate')"
      />
    </FormField>

    <div class="form-actions">
      <BaseButton type="submit" :disabled="isLoading">
        {{ isLoading ? 'Submitting...' : (submitLabel || 'Submit') }}
      </BaseButton>
    </div>
  </form>
</template>

<style scoped lang="scss">
.dynamic-form {
  max-width: 600px;
  margin: 0 auto;
  padding: 2rem;
  background: #fff;
  border-radius: 8px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.form-actions {
  margin-top: 2rem;
  display: flex;
  justify-content: flex-end;
}
</style>

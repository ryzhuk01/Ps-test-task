<script setup lang="ts">
defineProps<{
  modelValue: string | number;
  type?: 'text' | 'date' | 'number';
  placeholder?: string;
  id?: string;
  invalid?: boolean;
  max?: string;
}>();

defineEmits<{
  (e: 'update:modelValue', value: string | number): void;
}>();
</script>

<template>
  <input
    :type="type || 'text'"
    :value="modelValue"
    @input="$emit('update:modelValue', ($event.target as HTMLInputElement).value)"
    :placeholder="placeholder"
    :id="id"
    class="base-input"
    :class="{ 'is-invalid': invalid }"
    :max="max"
  />
</template>

<style scoped lang="scss">
.base-input {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 1rem;
  transition: border-color 0.2s;

  &:focus {
    outline: none;
    border-color: #42b983;
    box-shadow: 0 0 0 2px rgba(66, 185, 131, 0.2);
  }

  &.is-invalid {
    border-color: #dc3545;
    &:focus {
      box-shadow: 0 0 0 2px rgba(220, 53, 69, 0.2);
    }
  }
}
</style>

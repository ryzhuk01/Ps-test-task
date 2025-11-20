<script setup lang="ts">
defineProps<{
  label: string;
  error?: string;
  id?: string;
}>();
</script>

<template>
  <div class="form-field" :class="{ 'has-error': !!error }">
    <label :for="id" class="field-label">{{ label }}</label>
    <slot></slot>
    <span v-if="error" class="error-message">{{ error }}</span>
  </div>
</template>

<style scoped lang="scss">
.form-field {
  margin-bottom: 1.5rem;

  .field-label {
    display: block;
    margin-bottom: 0.5rem;
    font-weight: 500;
    color: #2c3e50;
  }

  .error-message {
    display: block;
    margin-top: 0.25rem;
    font-size: 0.875rem;
    color: #dc3545;
  }

  &.has-error {
    .field-label {
      color: #dc3545;
    }
  }
}
</style>

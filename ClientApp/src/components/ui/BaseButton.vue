<script setup lang="ts">
defineProps<{
  type?: 'button' | 'submit' | 'reset';
  variant?: 'primary' | 'secondary';
  disabled?: boolean;
}>();
</script>

<template>
  <button
    :type="type || 'button'"
    class="base-button"
    :class="variant || 'primary'"
    :disabled="disabled"
  >
    <slot></slot>
  </button>
</template>

<style scoped lang="scss">
.base-button {
  padding: 0.75rem 1.5rem;
  border: none;
  border-radius: 4px;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.1s;

  &:disabled {
    opacity: 0.6;
    cursor: not-allowed;
  }

  &.primary {
    background-color: #42b983;
    color: white;
    &:hover:not(:disabled) {
      background-color: #3aa876;
    }
    &:active:not(:disabled) {
      transform: translateY(1px);
    }
  }

  &.secondary {
    background-color: #6c757d;
    color: white;
    &:hover:not(:disabled) {
      background-color: #5a6268;
    }
  }
}
</style>
